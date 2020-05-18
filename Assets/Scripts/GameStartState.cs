using UnityEngine;

public class GameStartState : MonoBehaviour,IGameState
{
    /// <summary>経過時間/// </summary>
    private float deltaTime;
    /// <summary>待機時間</summary>
    private const float WAIT_TIME = 3.0f;
    /// <summary>ゲームディレクター</summary>
    private GameDirector gD;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;

        // 指定の時間が経過したか判別
        if (deltaTime > WAIT_TIME)
        {
            // 経過した場合

            // リザルト状態に切替
            SwitchPlayState();
        }
    }

    public void Action()
    {
        deltaTime = 0.0f;
        gD = GetComponent<GameDirector>();
        gD.aM.PlaySE(gD.aM.GameStartSE.name);
        gD.TargetObjects[(int)GameDirector.STATUS.START_STATUS].SetActive(true);
        GameDirector.score = 0;
    }

    /// <summary>
    /// プレイ状態に切り替え
    /// </summary>
    public void SwitchPlayState()
    {
        gD.TargetObjects[(int)GameDirector.STATUS.START_STATUS].SetActive(false);
        var state = GetComponent<GamePlayState>();
        state.enabled = true;
        gD.SwitchState(state);
        this.enabled = false;
    }
}
