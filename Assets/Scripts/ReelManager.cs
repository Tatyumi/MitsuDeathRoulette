using UnityEngine;

public class ReelManager : MonoBehaviour
{
    /// <summary>上段のリールの柄</summary>
    public GameObject[] TopReelPatterns;
    /// <summary>下段のリールの柄</summary>
    public GameObject[] BottomReelPatterns;
    /// <summary>パネルマネージャー</summary>
    public PanelManager pM;
    /// <summary>現在の状態</summary>
    public IReelState CurrentState;

    public AudioManager aM;


    /// <summary>
    /// リール列挙
    /// </summary>
    public enum REEL
    {
        TOP,
        BOTTOM
    }

    /// <summary>
    /// 上段リールの柄列挙
    /// </summary>
    public enum TOP_REEL_PATTERN
    {
        U_CROWN,
        KUSA_U_CROWN,
        TAKE_U_CROWA
    }

    /// <summary>
    /// 下段リールの柄列挙
    /// </summary>
    public enum BOTTOM_REEL_STATUS
    {
        YAMA,
        MUSHI,
        ME,
        NONE
    }


    // Use this for initialization
    void Start()
    {
        aM = AudioManager.Instance;

        this.GetComponent<ReelStopState>().enabled = false;
        this.GetComponent<ReelWaitState>().enabled = true;
        this.GetComponent<ReelMoveState>().enabled = false;
        SwitchState(this.GetComponent<ReelMoveState>());
    }

    // Update is called once per frame
    void Update()
    {
    }


    /// <summary>
    /// 状態切替
    /// </summary>
    public void SwitchState(IReelState state)
    {
        // コンポーネントの有効無効の切り替えを行う
        // または。アクションをUpdateで行う

        CurrentState = null;
        CurrentState = state;

        if (CurrentState != null)
        {
            CurrentState.Action();
        }
    }
}
