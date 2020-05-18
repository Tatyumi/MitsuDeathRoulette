using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelWaitState : MonoBehaviour, IReelState
{
    private ReelManager rM;
    /// <summary>経過時間</summary>
    private float deltaTime = 0.0f;
    /// <summary>待機時間</summary>
    private const float WAIT_TIME = 2.0f;
    /// <summary>レバーガイドの表示</summary>
    [SerializeField]
    private GameObject leverGuide;
    /// <summary>スコアテキスト</summary>
    [SerializeField]
    private GameObject scoreText;
    /// <summary>レバー</summary>
    [SerializeField]
    private GameObject lever;

    /// <summary>
    /// 待機状態の行動
    /// </summary>
    public void Action()
    {
        deltaTime = 0.0f;
        leverGuide.SetActive(false);

        // スコアテキスト更新
        scoreText.GetComponent<ScoreTextController>().ScoreDisp();

        lever.GetComponent<LeverController>().WaitLever();

    }

    private void Update()
    {
        deltaTime += Time.deltaTime;

        // レバーガイドの表示
        leverGuide.SetActive(deltaTime > WAIT_TIME);


        // 「↓」入力判別
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // 入力があった場合

            leverGuide.SetActive(false);

            // 切替
            var nextState = GetComponent<ReelMoveState>();
            nextState.enabled = true;
            lever.GetComponent<LeverController>().PullLever();
            rM = GetComponent<ReelManager>();
            rM.SwitchState(nextState);
            this.enabled = false;
        }
    }

}
