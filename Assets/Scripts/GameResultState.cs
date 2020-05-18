using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResultState : MonoBehaviour, IGameState
{

    private GameDirector gD;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // キー入力判別
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // スペースの入力があった場合

            gD.aM.StopSound();

            // やり直し
            Retry();
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            // 「B」の入力があった場合

            gD.aM.StopSound();

            // タイトルシーンに遷移
            MoveTitle();
        }

    }

    /// <summary>
    /// リザルト処理
    /// </summary>
    public void Action()
    {
        // TODO:ランキング登録
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(GameDirector.score);

        Debug.Log("Result");
        gD = GetComponent<GameDirector>();

        gD.TargetObjects[(int)GameDirector.STATUS.RESULT_STTATUS].SetActive(true);
        gD.aM.PlaySE(gD.aM.ResultScoreSE.name);

    }

    /// <summary>
    /// タイトルシーンに遷移
    /// </summary>
    public void MoveTitle()
    {
        SceneManager.LoadScene(SceneNameConstants.TITLE_SCENE);
    }

    /// <summary>
    /// ゲームシーンに遷移
    /// </summary>

    public void Retry()
    {
        SceneManager.LoadScene(SceneNameConstants.GAME_SCENE);
    }
}
