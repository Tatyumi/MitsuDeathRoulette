using UnityEngine;

public class GameDirector : MonoBehaviour
{
    /// <summary>スコア</summary>
    public static int score;
    /// <summary>現在の状態</summary>
    public IGameState CurrentState;
    /// <summary>制御対象オブジェクト</summary>
    public GameObject[] TargetObjects;
    public AudioManager aM;

    /// <summary>状態列挙</summary>
    public enum STATUS
    {
        TUTORIAL_STATUS,
        START_STATUS,
        PLAY_STATUS,
        END_STATUS,
        RESULT_STTATUS,
        BAD_END_STATUS
    }

    // Use this for initialization
    void Start()
    {
        aM = AudioManager.Instance;

        // 各オブジェクト非表示
        foreach (var obj in TargetObjects)
        {
            obj.SetActive(false);
        }

        // チュートリアル状態に切替
        var tutorialState = GetComponent<GameTutorialState>();

        tutorialState.enabled = true;
        GetComponent<GameStartState>().enabled = false;
        GetComponent<GamePlayState>().enabled = false;
        GetComponent<GameEndState>().enabled = false;
        GetComponent<GameBadEndState>().enabled = false;
        GetComponent<GameResultState>().enabled = false;

        SwitchState(tutorialState);
    }

    // Update is called once per frame
    void Update()
    {
    }


    /// <summary>
    /// 状態切替
    /// </summary>
    public void SwitchState(IGameState state)
    {
        // コンポーネントの有効無効の切り替えを行う
        // または。アクションをUpdateで行う

        CurrentState = null;
        CurrentState = state;

        if (CurrentState != null)
        {
            CurrentState.Action();
        }
    }
}
