using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームの状態
/// </summary>
public interface IGameState
{
    /// <summary>
    /// 状態に応じた処理
    /// </summary>
    void Action();
}