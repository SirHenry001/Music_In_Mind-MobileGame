using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;

    public int level1Stars;
    public int level2Stars;

    private void Awake()
    {
        gameManager = this;
    }

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

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Test()
    {
        print("GameManager");
    }
}
