using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// リールの状態
/// </summary>
public interface IReelState
{
    /// <summary>
    /// 状態に応じたアクション
    /// </summary>
    void Action();
}
