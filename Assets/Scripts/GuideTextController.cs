using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideTextController : MonoBehaviour
{
    /// <summary>サイズ変更速度</summary>
    private float changeSpeed = 15.5f;
    /// <summary>レクトトランスフォーム</summary>
    private RectTransform rect;

    // Use this for initialization
    void Start()
    {
        rect = this.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, 0);
    }

    // Update is called once per frame
    void Update()
    {
        

        // 指定のサイズを超えたか判別
        if(rect.sizeDelta.y > Screen.height || rect.sizeDelta.y < 0)
        {
            // 反転
            changeSpeed *= -1;
        }

        // サイズを更新
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + changeSpeed);
    }
}
