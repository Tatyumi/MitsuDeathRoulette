using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイトルシーンの状態
/// </summary>
public interface ITitleSceneState
{
    /// <summary>
    /// 状態に応じたアクション
    /// </summary>
    void Action();
}
