using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class TitleSceneManager : MonoBehaviour
{

    private AudioManager audioManager;


    // Use this for initialization
    void Start()
    {
        // スコア初期化
        GameDirector.score = 0;

        // BGM再生
        audioManager = AudioManager.Instance;
        audioManager.PlayBGM(audioManager.TitleSceneBGM.name);

    }

    // Update is called once per frame
    void Update()
    {
        // スペースキー入力判別
        if (Input.GetKey(KeyCode.Space))
        {
            // 入力があった場合

            audioManager.StopSound();

            audioManager.PlaySE(audioManager.SpaceKeySE.name);
            // ゲームシーンに遷移
            SceneManager.LoadScene(SceneNameConstants.GAME_SCENE);
        }
    }
}
