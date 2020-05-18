using UnityEngine;

public class GameTutorialState : MonoBehaviour, IGameState
{
    /// <summary>ゲームディレクター</summary>
    private GameDirector gD;

    // Update is called once per frame
    void Update()
    {
        // スペース入力判別
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 入力があった場合

            gD.aM.StopSound();
            gD.TargetObjects[(int)GameDirector.STATUS.TUTORIAL_STATUS].SetActive(false);

            // プレイ状態に遷移
            SwitchStartState();
        }
    }


    /// <summary>
    /// チュートリアル状態の処理
    /// </summary>
    public void Action()
    {
        // チュートリアルパネルの表示
        gD = GetComponent<GameDirector>();
        gD.TargetObjects[(int)GameDirector.STATUS.TUTORIAL_STATUS].SetActive(true);

        gD.aM.PlayBGM(gD.aM.TutorialBGM.name);
    }


    /// <summary>
    /// スタート状態に切り替え
    /// </summary>
    public void SwitchStartState()
    {
        var state = GetComponent<GameStartState>();
        state.enabled = true;
        gD.SwitchState(state);
        this.enabled = false;
    }
}