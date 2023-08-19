using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Controllers : MonoBehaviour
{
    public int score = 0;
    public bool gamePlay = true;
    public bool timeFlow;
    public bool isFinish;
    public float leftTime = 250f;
    
    
    private int highScore;
    private string nickName;
    private float bestTime;
    

    public TMP_Text timeText;
    public GameObject gamePanel, overPanel, nick, OkButton;
    public TMP_Text scoreText;
    public TMP_Text messageText;
    public TMP_Text finScoreText, finTimeText;
    public TMP_Text nickField;
    public TMP_Text bestField;

    [SerializeField] private Animator animator;


    
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        highScore = PlayerPrefs.GetInt("highScore", 0);
        bestTime = PlayerPrefs.GetFloat("bestTime", 0f);
        bestField.text = "BEST: " + PlayerPrefs.GetString("nickName", "Empty") + " - " + PlayerPrefs.GetInt("highScore", 0) + " - " + PlayerPrefs.GetFloat("bestTime", 0f);
    }

    // Update is called once per frame
    void Update()
    {

        //Oyun Akýþ
        if (gamePlay)
        {
            gamePanel.SetActive(true);
            leftTime -= Time.deltaTime;
            leftTime = (int)leftTime;
            timeText.text = leftTime + "";
            scoreText.text = "" + score;
            finTimeText.text = leftTime + "";
            finScoreText.text = "" + score;

        }
        else
        {
            if (isFinish == true)
            {
                gamePanel.SetActive(false);
                overPanel.SetActive(true);
                messageText.text = "Congruculations! You Win!";
                scoreText.text = "" + score;
                timeText.text = "" + leftTime;
                nick.SetActive(true);
                OkButton.SetActive(true);
            }
            else
            {
                animator.SetBool("isDie", true);
                gamePanel.SetActive(false);
                overPanel.SetActive(true);
                messageText.text = "Game Over!";
                scoreText.text = "" + score;
                timeText.text = "" + leftTime;
                nick.SetActive(false);
                OkButton.SetActive(false);
            }
           
        }


        //Skor Kontrol

        if (score < 0)
        {
            gamePlay = false;
            isFinish = false;
        }

        if (leftTime == 0f)
        {
            gamePlay = false;
            isFinish = false;
        }
    }

    public void newGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void highScoreFunc()
    {
        if (score >= highScore && leftTime >= bestTime && leftTime !< 1)
        {
                PlayerPrefs.SetInt("highScore", score);
                PlayerPrefs.SetFloat("bestTime", leftTime);
                PlayerPrefs.SetString("nickName", nickName);       
        }
    }

    public void sendButton()
    {
        nickName = nickField.text;
        highScoreFunc();
    }

}
