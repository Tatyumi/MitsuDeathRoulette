using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelMoveState : MonoBehaviour, IReelState
{
    /// <summary>リールの柄を切り替える時間</summary>
    public float switchPatternTime;
    /// <summary>初期回転速度</summary>
    public const float INI_MODE_SPEED = 0.45f;

    /// <summary>経過時間</summary>
    private float deltaTime;
    /// <summary>リールマネージャー</summary>
    private ReelManager rM;

    private void Awake()
    {
        switchPatternTime = INI_MODE_SPEED;
    }


    /// <summary>
    /// 「MOVE」での行動
    /// </summary>
    public void Action()
    {
        rM = GetComponent<ReelManager>();
        rM.pM.IniDisp();
        // 柄切替
        SwitchReelPattern(rM.TopReelPatterns);
        SwitchReelPattern(rM.BottomReelPatterns);
    }

    private void Update()
    {
        deltaTime += Time.deltaTime;

        // 指定の時間が経過したか判別
        if (deltaTime > switchPatternTime)
        {
            // 経過した場合

            deltaTime = 0.0f;

            rM.aM.PlaySE(rM.aM.ChangeReelPatternSE.name);

            // 柄切替
            SwitchReelPattern(rM.TopReelPatterns);
            SwitchReelPattern(rM.BottomReelPatterns);
        }

        // スペースキー入力判別
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 入力があった場合

            deltaTime = 0.0f;

            // STOP状態に切り替える
            var stopState = rM.GetComponent<ReelStopState>();
            stopState.enabled = true;
            rM.SwitchState(stopState);
            rM.GetComponent<ReelMoveState>().enabled = false;
        }
    }


    /// <summary>
    /// リールの柄切替
    /// </summary>
    private void SwitchReelPattern(GameObject[] reel)
    {
        int dispPatternNum = Random.Range(0, reel.Length);

        // 現在表示している要素番号 % 配列数
        for (int i = 0; i < reel.Length; i++)
        {
            reel[i].SetActive(i == dispPatternNum);
        }
    }
}