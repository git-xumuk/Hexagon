using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject mainMenu;
    public GameObject retryMenu;
    public Button playButton, retryButton;

    public Text scoreText;
    public Text highScoreText;

    public int score;
    public int highScore;
    bool isStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        score = 0;
        retryMenu.SetActive(false);
        mainMenu.SetActive(true);

        playButton.onClick.AddListener(delegate
       {
           mainMenu.SetActive(false);
           isStarted = true;
       });
    }

    // Update is called once per frame
    void Update()
    {
        retryButton.onClick.AddListener(delegate
        {
            score = 0;
            retryMenu.SetActive(false);
            PlayerControl.isDead = false;
            isStarted = true;
        });

        if (PlayerControl.isDead)
        {
            isStarted = false;
            tryIncreaseHighScore(score);

            if (PlayerPrefs.GetInt("HighScore") < highScore)
                PlayerPrefs.SetInt("HighScore", highScore);

            retryMenu.SetActive(true);
        }
    }

    public bool getIsStarted()
    {
        return isStarted;
    }

    public void increaseScore(int increment)
    {
        score += increment;
        scoreText.text = "Score: " + score;
    }

    public void tryIncreaseHighScore(int thisScore)
    {
        if (thisScore > highScore)
            highScore = thisScore;
    }
}

    
