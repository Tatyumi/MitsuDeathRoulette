using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    /// <summary>タイトルBGM</summary>
    public AudioClip TitleSceneBGM;
    /// <summary>チュートリアルBGM</summary>
    public AudioClip TutorialBGM;
    /// <summary>プレイBGM</summary>
    public AudioClip GamePlayBGM;

    /// <summary>ゲーム終了SE</summary>
    public AudioClip GameEndSE;
    /// <summary>ゲーム開始SE</summary>
    public AudioClip GameStartSE;
    /// <summary>スコア表示SE</summary>
    public AudioClip ResultScoreSE;
    /// <summary>スペースキー押したときのSE</summary>
    public AudioClip SpaceKeySE;
    /// <summary>レバーSE</summary>
    public AudioClip LeverSE;
    /// <summary>リールの柄変更SE</summary>
    public AudioClip ChangeReelPatternSE;
    /// <summary>正解SE</summary>
    public AudioClip RightSE;
    /// <summary>はてな時SE</summary>
    public AudioClip HatenaSE;
    /// <summary>不正解(密)</summary>
    public AudioClip WrongSE;

    /// <summary>オーディオソース</summary>
    AudioSource audioSource;
    /// <summary>全SE保持ディクショナリ</summary>
    private Dictionary<string, AudioClip> SEDic;
    /// <summary>全BGM保持ディクショナリ</summary>
    private Dictionary<string, AudioClip> BGMDic;
    /// <summary>初期ボリューム</summary>
    private float defaultVolume = 0.5f;
    /// <summary>フェードスピード</summary>
    private float fadeSpeed = 0.2f;
    /// <summary>フェードアウトフラグ</summary>
    private bool isFadeOut;


    private void Awake()
    {
        // 存在確認
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        // フラグ初期化
        isFadeOut = false;

        // AudioSourceコンポーネントの取得
        audioSource = gameObject.GetComponent<AudioSource>();

        // 音量の初期化
        audioSource.volume = defaultVolume;

        // SEを格納
        SEDic = new Dictionary<string, AudioClip>
        {
            {GameEndSE.name, GameEndSE},
            {GameStartSE.name, GameStartSE},
            {ResultScoreSE.name, ResultScoreSE},
            {SpaceKeySE.name, SpaceKeySE},
            {LeverSE.name, LeverSE},
            {ChangeReelPatternSE.name, ChangeReelPatternSE},
            {RightSE.name,RightSE },
            {HatenaSE.name, HatenaSE},
            {WrongSE.name, WrongSE}
        };

        // BGMを格納
        BGMDic = new Dictionary<string, AudioClip>
        {
            { TitleSceneBGM.name,TitleSceneBGM},
            { TutorialBGM.name,TutorialBGM},
            { GamePlayBGM.name,GamePlayBGM}
        };
    }


    private void Update()
    {
        // フラグチェック
        if (isFadeOut)
        {
            // trueの場合

            // 徐々にボリュームを下げる
            audioSource.volume -= Time.deltaTime * fadeSpeed;

            // ボリュームが0以下か判別
            if (audioSource.volume <= 0)
            {
                // 0以下の場合

                // 音の停止
                audioSource.Stop();

                // ボリュームを初期値に戻す
                audioSource.volume = defaultVolume;

                // フラグ更新
                isFadeOut = false;
            }
        }
    }

    /// <summary>
    /// BGMの再生
    /// </summary>
    /// <param name="BGMName">BGMの名前</param>
    public void PlayBGM(string BGMName)
    {
        // 名前の存在チェック
        if (!BGMDic.ContainsKey(BGMName))
        {
            // 該当しない場合

            // ログを表示
            Debug.Log(BGMName + "という名前のBGMがありません");
            return;
        }

        // 現在再生しているBGMを停止する
        audioSource.Stop();

        // BGMの再生
        audioSource.clip = BGMDic[BGMName] as AudioClip;
        audioSource.Play();
    }


    /// <summary>
    /// SEの再生
    /// </summary>
    /// <param name="SEName">SEの名前</param>
    public void PlaySE(string SEName)
    {
        // 名前の存在チェック
        if (!SEDic.ContainsKey(SEName))
        {
            // 該当しない場合

            // ログを表示
            Debug.Log(SEName + "という名前のSEがありません");
            return;
        }

        // SEの再生
        audioSource.PlayOneShot(SEDic[SEName]);
    }

    /// <summary>
    /// 音を停止
    /// </summary>
    public void StopSound()
    {
        // 再生中の音をすべて停止する
        audioSource.Stop();
    }
}