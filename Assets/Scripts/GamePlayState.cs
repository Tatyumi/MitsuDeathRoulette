using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayState : MonoBehaviour, IGameState
{
    /// <summary>密フラグ</summary>
    public bool isMitsu;
    /// <summary>ゲームディレクター</summary>
    private GameDirector gD;
    /// <summary>制限時間</summary>
    private const float TIME_LIMIT = 20.0f;
    /// <summary>経過時間</summary>
    private float deltaTime;

    [SerializeField]
    private GameObject rMState;

    [SerializeField]
    private Text timeText;

    private void Awake()
    {
        isMitsu = false;
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        timeText.text = (TIME_LIMIT - deltaTime).ToString("0");

        // 「密」が起きた時にリザルト状態に移行
        if (isMitsu)
        {
            SwitchBadEndState();
        }

        // 経過時間が制限に達したか
        if (deltaTime > TIME_LIMIT)
        {
            // 達した場合

            gD.aM.StopSound();
            SwitchEndState();
        }
    }


    /// <summary>
    /// ゲームプレイ状態の処理
    /// </summary>
    public void Action()
    {
        isMitsu = false;
        deltaTime = 0.0f;

        // プレイ画面の表示
        gD = GetComponent<GameDirector>();
        gD.TargetObjects[(int)GameDirector.STATUS.PLAY_STATUS].SetActive(true);

        gD.aM.PlayBGM(gD.aM.GamePlayBGM.name);
    }


    /// <summary>
    /// 終了状態に切り替え
    /// </summary>
    public void SwitchEndState()
    {
        var state = GetComponent<GameEndState>();
        state.enabled = true;
        NonEnableReel();
        gD.SwitchState(state);
        this.enabled = false;
    }


    /// <summary>
    /// コロナエンド状態に切り替え
    /// </summary>
    public void SwitchBadEndState()
    {
        var state = GetComponent<GameBadEndState>();
        state.enabled = true;
        NonEnableReel();
        gD.SwitchState(state);
        this.enabled = false;
    }

    /// <summary>
    /// リールを無効にする
    /// </summary>
    private void NonEnableReel()
    {
        rMState.GetComponent<ReelMoveState>().enabled = false;
        rMState.GetComponent<ReelStopState>().enabled = false;
        rMState.GetComponent<ReelWaitState>().enabled = false;

    }
}