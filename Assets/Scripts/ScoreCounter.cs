using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreCounter : MonoBehaviour
{
    private float score = 0;


    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textScoreDiePanel;
    public TextMeshProUGUI textScoreLevelCompletePanel;
    public TextMeshProUGUI highScoreDiePanel;
    public TextMeshProUGUI highScoreLevelCompletePanel;
    public TextMeshProUGUI CombatScoreText;  //Add reference to UI Text here via the inspector


    public GameObject ScoreAnimation1;










    private int scorePoint = 0;


    void Start()
    {


        highScoreDiePanel.text = PlayerPrefs.GetFloat("HighScore").ToString();
        highScoreLevelCompletePanel.text = PlayerPrefs.GetFloat("HighScore").ToString();

    }
    void Update()
    {

        scorePoint = 0;


        GameObject thePlayer = GameObject.Find("Player");
        PlayerEverything player1 = thePlayer.GetComponent<PlayerEverything>();




        if (player1.isGrounded && Time.timeScale==1 && PauseMenu.GameIsPaused==false)
        {
            scorePoint += 1;
            score += scorePoint;
            ScoreAnimation1.GetComponent<Animator>().Play("ScoreAnimation1");

            textScore.text = score.ToString();
            textScoreDiePanel.text = score.ToString();
            textScoreLevelCompletePanel.text = score.ToString();


            GetHighScore();
        }


    }



    void GetHighScore()
    {
        if (score > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", score);
            highScoreDiePanel.text = score.ToString();
            highScoreLevelCompletePanel.text = score.ToString();

        }
    }



    // Update is called once per frame

}
