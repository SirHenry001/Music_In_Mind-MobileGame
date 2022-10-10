using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;
    public CollisionScript collisionScript;

    public int level1Stars;
    public int level2Stars;
    public int level3Stars;

    public int level1Score;
    public int level2Score;
    public int level3Score;



    // Start is called before the first frame update
    void Start()
    {

        if(gameManager == null)
        {
            //gamemangeri ei tuhoudu scenejen välillä!!
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }

        else if(gameManager != null )
        {
            Destroy(gameObject);
        }

        level1Stars = PlayerPrefs.GetInt("highScore1");
        level2Stars = PlayerPrefs.GetInt("highScore2");
        level3Stars = PlayerPrefs.GetInt("highScore3");

        //hiScoreText1 = collisionScript.scoreText.GetComponent<TextMeshProUGUI>().text = level1Score.ToString();

        level1Score = PlayerPrefs.GetInt("levelScore1");
        level2Score = PlayerPrefs.GetInt("levelScore2");
        level3Score = PlayerPrefs.GetInt("levelScore3");



    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
