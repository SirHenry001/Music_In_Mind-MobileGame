using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    //TIMER THAT DETERMINE PLAYER SCORE
    public float timer;

    public float rewardTime1, rewardTime2, rewardTime3;

    public int starsGained;
    static int starsRecord; 

    public bool gameOver = false;

    public GameObject levelPopUp;
    public GameObject[] stars;
    public int nextLevel;

    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if(!gameOver)
        {
            timer += Time.deltaTime;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !gameOver)
        {
            print("osuma");
            levelPopUp.SetActive(true);
            gameOver = true;
            
            for(int i = 0; i < stars.Length; i++)
            {
                stars[i].SetActive(false);
            }

            if (timer >= rewardTime1)
            {
                starsGained = 1;
            }

            if (timer >= rewardTime2)
            {
                starsGained = 2;
            }

            if (timer >= rewardTime3)
            {
                starsGained = 3;
            }

            if(starsGained > starsRecord)
            {
                starsRecord = starsGained;
            }

            gameManager.level1Stars = starsRecord;

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
}
