using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトルシーン待機状態クラス
/// </summary>
public class TitleSceneWaitState : ITitleSceneState
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public TitleSceneWaitState()
    {
    }

    /// <summary>
    /// 待機状態のアクション
    /// </summary>
    public void Action()
    {
        // スペースキー入力判別
        if (Input.GetKey(KeyCode.Space))
        {
            // 入力があった場合

            // ゲームシーンに遷移
            SceneManager.LoadScene(SceneNameConstants.GAME_SCENE);
        }
    }
}
