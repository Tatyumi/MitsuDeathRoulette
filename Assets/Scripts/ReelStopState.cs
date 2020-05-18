using UnityEngine;

public class ReelStopState : MonoBehaviour, IReelState
{
    private ReelManager rM;
    /// <summary>上段リールの停止番号</summary>
    private int topNum;
    /// <summary>下段リールの停止番号</summary>
    private int bottomNum;

    [SerializeField]
    private GameObject gObj;

    private GameDirector gD;

    /// <summary>
    /// Stopでの行動
    /// </summary>
	public void Action()
    {
        rM = GetComponent<ReelManager>();

        int count = 0;
        foreach (var reel in rM.TopReelPatterns)
        {
            if (reel.activeSelf)
            {
                topNum = count;
                count = 0;
                break;
            }
            count++;
        }

        foreach (var reel in rM.BottomReelPatterns)
        {
            if (reel.activeSelf)
            {
                bottomNum = count;
                count = 0;
                break;
            }
            count++;
        }
        Debug.Log("topNum:" + topNum);
        Debug.Log("bottomNum:" + bottomNum);


        // 上段の柄判別
        switch (topNum)
        {
            case (int)ReelManager.TOP_REEL_PATTERN.U_CROWN:
                Debug.Log("ウ冠");

                // ウ冠の場合
                if (bottomNum == (int)ReelManager.BOTTOM_REEL_STATUS.YAMA)
                {
                    // 密、終了
                    Debug.Log("みつ");
                    rM.pM.DispBadMitsu();
                    Wrong();
                }
                else if (bottomNum == (int)ReelManager.BOTTOM_REEL_STATUS.MUSHI)
                {
                    Debug.Log("むし");
                    rM.pM.DispMitsu();
                    Right();
                }
                else if (bottomNum == (int)ReelManager.BOTTOM_REEL_STATUS.NONE)
                {
                    Debug.Log("ひつ");
                    rM.pM.DispHitsu();
                    Right();


                }
                else if (bottomNum == (int)ReelManager.BOTTOM_REEL_STATUS.ME)
                {
                    Debug.Log("もく");
                    rM.pM.DispMoku();
                    Right();
                }
                else
                {
                    // 存在しない
                    Debug.Log("なし");
                    Retry();
                }
                break;

            case (int)ReelManager.TOP_REEL_PATTERN.KUSA_U_CROWN:
                // 草ウ冠
                Debug.Log("草ウ冠");

                if (bottomNum == (int)ReelManager.BOTTOM_REEL_STATUS.YAMA)
                {
                    Debug.Log("びつ");
                    rM.pM.DispBitsuMitsu();
                    Right();
                }
                else
                {
                    Debug.Log("なし");
                    // 存在しない
                    Retry();
                }


                break;

            case (int)ReelManager.TOP_REEL_PATTERN.TAKE_U_CROWA:
                // 竹ウ冠
                Debug.Log("竹ウ冠");


                if (bottomNum == (int)ReelManager.BOTTOM_REEL_STATUS.YAMA)
                {
                    Debug.Log("べつ");
                    rM.pM.DispBetsu();
                    Right();
                }
                else
                {
                    Debug.Log("なし");
                    // 存在しない
                    Retry();
                }
                break;
        }

    }


    /// <summary>
    /// 正解
    /// </summary>
    private void Right()
    {
        rM.aM.PlaySE(rM.aM.RightSE.name);

        GameDirector.score++;
        rM.pM.SwitchEye(PanelManager.EYE_DISP.SMILE);
        SwitchWaitState();
    }

    /// <summary>
    /// 不正解
    /// </summary>
    private void Wrong()
    {
        rM.aM.StopSound();
        rM.aM.PlaySE(rM.aM.WrongSE.name);

        rM.pM.SwitchEye(PanelManager.EYE_DISP.MITSU);
        gObj.GetComponent<GamePlayState>().isMitsu = true;
    }


    /// <summary>
    /// 再挑戦
    /// </summary>
    private void Retry()
    {
        rM.aM.PlaySE(rM.aM.HatenaSE.name);

        rM.pM.DispHatena();
        SwitchWaitState();
    }


    /// <summary>
    /// 待機状態に切り替える
    /// </summary>
    private void SwitchWaitState()
    {
        // 待機状態に切り替える
        var state = rM.GetComponent<ReelWaitState>();
        state.enabled = true;
        rM.SwitchState(state);
        rM.GetComponent<ReelStopState>().enabled = false;
    }
}