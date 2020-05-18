using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndState : MonoBehaviour, IGameState
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
        if(deltaTime > WAIT_TIME)
        {
            // 経過した場合

            // リザルト状態に切替
            SwitchResultState();
        }
    }


    /// <summary>
    /// 終了状態の処理
    /// </summary>
    public void Action()
    {
        Debug.Log("End");
        deltaTime = 0.0f;
        gD = GetComponent<GameDirector>();

        gD.TargetObjects[(int)GameDirector.STATUS.END_STATUS].SetActive(true);
        gD.aM.PlaySE(gD.aM.GameEndSE.name);
    }


    /// <summary>
    /// リザルト状態に切り替え
    /// </summary>
    public void SwitchResultState()
    {
        var state = GetComponent<GameResultState>();
        state.enabled = true;
        gD.SwitchState(state);
        this.enabled = false;
    }
}