using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    //public GameObject audioManager;
    //VARIABLES FOR POP UP SCREENS
    public GameObject levelPopUp;
    public TextMeshProUGUI levelText;
    public GameObject optionsPopUp;
    public GameObject aboutPopUp;
    public GameObject infoPopUp;
    public GameObject quitPopUp;
    public GameObject levelList;

    public TextMeshProUGUI hiScoreText1;
    public TextMeshProUGUI hiScoreText2;
    public TextMeshProUGUI hiScoreText3;

    public GameObject playButton;
    public GameObject aboutButton;
    public GameObject settingsButton;
    public GameObject howToPlayButton;
    public GameObject quitButton;
    public GameObject logoImage;
    public GameObject logoMenuImage;
    public GameObject fadeImage;

    //VARIABLES FOR STAR IMAGES DISPLAYED ON LEVEL BUTTONS ON LEVEL SCREEN
    public GameObject[] level1StarsImages;
    public GameObject[] level2StarsImages;
    public GameObject[] level3StarsImages;

    public ParticleSystem buttonEffects;
    public Animator myAnimator;

    public AudioSource playButtonSource;
    public AudioSource myAudio;
    public AudioClip playClip;
    public AudioClip startClip;
    public AudioClip cancelClip;

        public int level1Score;
    public int level2Score;
    public int level3Score;

    public GameManager gameManager;

    public int nextLevel;


    // Start is called before the first frame update
    void Start()
    {

        level1Score = PlayerPrefs.GetInt("levelScore1");
        level2Score = PlayerPrefs.GetInt("levelScore2");
        level3Score = PlayerPrefs.GetInt("levelScore3");

        levelPopUp.SetActive(false);
        fadeImage.SetActive(true);

        myAnimator = GameObject.Find("FadeOut").GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void GameStart()
    {
        StartCoroutine(StartTimer());
    }

    public void LevelScreenActive(int level)
    {

        levelPopUp.SetActive(true);
        nextLevel = level;
        levelText.text = "Go To Level" + level.ToString();

        if(level == 1 )
        {
            hiScoreText1.GetComponent<TextMeshProUGUI>().text = "High Score" + level1Score.ToString();
        }

        if (level == 2)
        {
            hiScoreText2.GetComponent<TextMeshProUGUI>().text = "High Score" + level2Score.ToString();
        }

        if (level == 3)
        {
            hiScoreText3.GetComponent<TextMeshProUGUI>().text = "High Score" + level3Score.ToString();
        }
    }

    public void LevelScreenClose()
    {
        myAudio.PlayOneShot(cancelClip);
        levelPopUp.GetComponent<Animator>().SetBool("Disappear", true);
    }

    public void OpenAbout()
    {
        aboutPopUp.SetActive(true);
        aboutPopUp.GetComponent<Animator>().SetBool("Appear", true);
    }

    public void CloseAbout()
    {
        myAudio.PlayOneShot(cancelClip);
        aboutPopUp.GetComponent<Animator>().SetBool("Appear", false);
        aboutPopUp.GetComponent<Animator>().SetBool("Disappear", true);
    }

    public void OpenOptions()
    {
        optionsPopUp.SetActive(true);
        optionsPopUp.GetComponent<Animator>().SetBool("Appear", true);
    }

    public void CloseOptions()
    {
        myAudio.PlayOneShot(cancelClip);
        optionsPopUp.GetComponent<Animator>().SetBool("Appear", false);
        optionsPopUp.GetComponent<Animator>().SetBool("Disappear", true);
    }

    public void OpenInfo()
    {
        infoPopUp.SetActive(true);
        infoPopUp.GetComponent<Animator>().SetBool("Appear", true);
    }

    public void CloseInfo()
    {
        myAudio.PlayOneShot(cancelClip);
        infoPopUp.GetComponent<Animator>().SetBool("Appear", false);
        infoPopUp.GetComponent<Animator>().SetBool("Disappear", true);
    }

    public void OpenQuit()
    {
        quitPopUp.SetActive(true);
        quitPopUp.GetComponent<Animator>().SetBool("Appear", true);
    }

    public void CloseQuit()
    {
        quitPopUp.GetComponent<Animator>().SetBool("Appear", false);
        quitPopUp.GetComponent<Animator>().SetBool("Disappear", true);
    }

    public void OpenLevel()
    {

        StartCoroutine(OpenLevelDelay());
        
    }

    public void OpenLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void OpenLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator StartTimer()
    {
        playButton.GetComponent<Animator>().SetTrigger("Pressed");
        buttonEffects.Play();
        playButtonSource.PlayOneShot(playClip);
        yield return new WaitForSeconds(0.5f);
        logoMenuImage.SetActive(true);
        logoImage.SetActive(false);
        levelList.SetActive(true);
        quitButton.SetActive(true);
        aboutButton.SetActive(true);
        settingsButton.SetActive(true);
        howToPlayButton.SetActive(true);
        playButton.SetActive(false);

        for(int i = 0; i < gameManager.level1Stars; i++)
        {
            level1StarsImages[i].SetActive(true);
        }

        for (int i = 0; i < gameManager.level2Stars; i++)
        {
            level2StarsImages[i].SetActive(true);
        }

        for (int i = 0; i < gameManager.level3Stars; i++)
        {
            level3StarsImages[i].SetActive(true);
        }
    }

    public IEnumerator OpenLevelDelay()
    {
        myAudio.PlayOneShot(startClip);
        myAnimator.SetBool("FadeIn", false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextLevel);
    }

}
