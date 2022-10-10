using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    //CURRENT SCORE THAT DETERMINE PLAYER SCORE
    public int score;
    static int scoreRecord;

    //SCORES THAT TELL THE LIMIT FOR STARS APPEAR
    public int rewardScore1, rewardScore2, rewardScore3;

    //INTEGERS TO COMPARE RECORD/COLLECTED STARS
    public int starsGained;
    static int starsRecord;


    //TouchAim gameobject
    public Transform touch;

    //BOOLEAN TO CHECK IF GAME IS OVER
    public bool gameOver = false;

    //GAMEOBJECT TO PICKUPMAX
    public GameObject pickUpMax;

    //VARIABLES FOR UI TO POP UP ON DIFFERENT FUNCTIONS
    public GameObject levelPopUp;
    public GameObject[] stars;
    public int nextLevel;

    public Image noteMeter;
    public GameObject scoreText;
    public GameObject scoreMenuText;
    public GameObject timeOutText;
    public float meterValue;
    public float timer;
    public int difficultLevel;
    public float intervalTime;

    public string levelName;
    public string scoreName;

    //ACCESS TO OTHER SCRIPTS
    public GameManager gameManager;
    public AudioManager audioManager;
    public MusicManager musicManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        musicManager = GameObject.Find("MusicPlayer").GetComponent<MusicManager>();
        touch = GameObject.Find("HeroAim").transform;
    }

    private void Update()
    {
        //show schore on the screen
        scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
        scoreMenuText.GetComponent<TextMeshProUGUI>().text = score.ToString();



        /*
        PlayerPrefs.SetInt("HiScoreText1", score);
        PlayerPrefs.Save();
        */

        if (difficultLevel > 5)
        {
            difficultLevel = 5;
        }

        timer += Time.deltaTime;

        if (timer >= intervalTime)
        {
            difficultLevel += 1;
            pickUpMax.SetActive(true);
            timer = 0;
        }

        if (meterValue >= 1000)
        {
            meterValue = 1000;
        }

        if (meterValue <= 0)
        {
            levelPopUp.SetActive(true);
            timeOutText.SetActive(true);
            
            gameOver = true;
        }

        if (gameOver)
        {
            touch.GetComponent<CircleCollider2D>().enabled = false;
        }

    }

    private void FixedUpdate()
    {
        if(!gameOver)
        {
            NoteMeter(1);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ENEMY TAG RELATED COLLISIONS
        if (collision.gameObject.tag == "Enemy" && !gameOver)
        {
            levelPopUp.SetActive(true);
            audioManager.PlayAudio(3);
            musicManager.StopMusic();

            gameOver = true;
            
            for(int i = 0; i < stars.Length; i++)
            {
                stars[i].SetActive(false);
            }

            if (score >= rewardScore1)
            {
                starsGained = 1;
            }

            if (score >= rewardScore2)
            {
                starsGained = 2;
            }

            if (score >= rewardScore3)
            {
                starsGained = 3;
            }

            if(starsGained > starsRecord)
            {
                starsRecord = starsGained;
                PlayerPrefs.SetInt(levelName, starsRecord);
            }

            if (score > scoreRecord)
            {
                scoreRecord = score;
                PlayerPrefs.SetInt(scoreName, scoreRecord);
            }

            gameManager.level1Stars = starsRecord;
            gameManager.level2Stars = starsRecord;
            gameManager.level3Stars = starsRecord;

            gameManager.level1Score = scoreRecord;
            gameManager.level2Score = scoreRecord;
            gameManager.level3Score = scoreRecord;


            StartCoroutine(StarAppear());

        }
    }

    public IEnumerator StarAppear()
    {
        yield return new WaitForSeconds(1);

        for (int i = 0; i < starsGained; i++)
        {
            stars[i].SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void LevelScreenActive(int level)
    {
        levelPopUp.SetActive(true);
        nextLevel = level;
    }

    public void OpenLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }

    public void NoteMeter(float value)
    {
        meterValue -= value;
        noteMeter.fillAmount = meterValue * 0.001f;
    }

    public void AddTime(float value)
    {
        meterValue += value;
        noteMeter.fillAmount = meterValue * 0.001f;
    }

    public void Score(int value)
    {
        score += value;
    }
}
