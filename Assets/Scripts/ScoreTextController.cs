using UnityEngine;
using UnityEngine.UI;

public class ScoreTextController : MonoBehaviour {

    [SerializeField]
    private Text scoreText;
	
	// Update is called once per frame
	void Update () {

		
	}


    /// <summary>
    /// スコアテキストを表示
    /// </summary>
    public void ScoreDisp()
    {
        scoreText.text = GameDirector.score.ToString("00");
    }
}
