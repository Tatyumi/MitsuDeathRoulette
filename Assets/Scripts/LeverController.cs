using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour {

    /// <summary>レバーを引くアニメーション</summary>
    //private Animator pullLeverAnim;
    private Animator pullLeverAnim;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager aM;

    /// <summary>
    /// アニメーション状態
    /// </summary>
    private enum ANIM_STATUS
    {
        WAIT,
        PULL
    }


	// Use this for initialization
	void Start () {
        pullLeverAnim = gameObject.GetComponent<Animator>();
        WaitLever();

        aM = AudioManager.Instance;
	}
	
    /// <summary>
    /// レバーを引く状態
    /// </summary>
    public void PullLever()
    {
        pullLeverAnim.SetInteger("isPull", (int)ANIM_STATUS.PULL);
        aM.PlaySE(aM.LeverSE.name);
    }

    /// <summary>
    /// レバー待機状態
    /// </summary>
    public void WaitLever()
    {
        pullLeverAnim.SetInteger("isPull", (int)ANIM_STATUS.WAIT);
    }
}
