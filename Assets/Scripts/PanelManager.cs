using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {
    /// <summary>左パネルに表示する画像</summary>
    [SerializeField]
    private GameObject[] leftPanelImgs;
    /// <summary>右パネルに表示する画像</summary>
    [SerializeField]
    private GameObject[] rightPanelImgs;
    /// <summary>目パネル</summary>
    [SerializeField]
    private GameObject[] eyePanelImgs;

    public enum EYE_DISP
    {
        CLOSE,
        SMILE,
        MITSU
    }

    private enum LEFT_DISP_IMG
    {
        MITSU,
        HITSU,
        BETSU,
        MOKU,
        BADMITSU,
        BITSU,
        HATENA
    }

    private enum RIGHT_DISP_IMG
    {
        DESU,
        BADDESU,
        HATENA
    }


    /// <summary>
    /// 初期状態
    /// </summary>
    public void IniDisp()
    {
        foreach(var img in leftPanelImgs)
        {
            img.SetActive(false);
        }

        foreach (var img in rightPanelImgs)
        {
            img.SetActive(false);
        }

        SwitchEye(EYE_DISP.CLOSE);
    }


    /// <summary>
    /// 目の画像の切り替え
    /// </summary>
    /// <param name="eyeState"></param>
    public void SwitchEye(EYE_DISP eyeState)
    {
        int count = 0;

        foreach(var eye in eyePanelImgs)
        {
            eye.SetActive(count == (int)eyeState);

            count++;
        }
    }


    /// <summary>
    ///  「蜜」を表示
    /// </summary>
    public void DispMitsu()
    {
        leftPanelImgs[(int)LEFT_DISP_IMG.MITSU].SetActive(true);
        rightPanelImgs[(int)RIGHT_DISP_IMG.DESU].SetActive(true);
    }


    /// <summary>
    ///  「ひつ」を表示
    /// </summary>
    public void DispHitsu()
    {
        leftPanelImgs[(int)LEFT_DISP_IMG.HITSU].SetActive(true);
        rightPanelImgs[(int)RIGHT_DISP_IMG.DESU].SetActive(true);
    }


    /// <summary>
    ///  「べつ」を表示
    /// </summary>
    public void DispBetsu()
    {
        leftPanelImgs[(int)LEFT_DISP_IMG.BETSU].SetActive(true);
        rightPanelImgs[(int)RIGHT_DISP_IMG.DESU].SetActive(true);
    }


    /// <summary>
    ///  「もく」を表示
    /// </summary>
    public void DispMoku()
    {
        leftPanelImgs[(int)LEFT_DISP_IMG.MOKU].SetActive(true);
        rightPanelImgs[(int)RIGHT_DISP_IMG.DESU].SetActive(true);
    }


    /// <summary>
    ///  赤「みつ」を表示
    /// </summary>
    public void DispBadMitsu()
    {
        leftPanelImgs[(int)LEFT_DISP_IMG.BADMITSU].SetActive(true);
        rightPanelImgs[(int)RIGHT_DISP_IMG.BADDESU].SetActive(true);
    }


    /// <summary>
    ///  「びつ」を表示
    /// </summary>
    public void DispBitsuMitsu()
    {
        leftPanelImgs[(int)LEFT_DISP_IMG.BITSU].SetActive(true);
        rightPanelImgs[(int)RIGHT_DISP_IMG.DESU].SetActive(true);
    }

    /// <summary>
    /// 「？」を表示
    /// </summary>
    public void DispHatena()
    {
        leftPanelImgs[(int)LEFT_DISP_IMG.HATENA].SetActive(true);
        rightPanelImgs[(int)RIGHT_DISP_IMG.HATENA].SetActive(true);
    }

}
