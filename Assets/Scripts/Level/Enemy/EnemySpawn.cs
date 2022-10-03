using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] spawner;

    public static EnemySpawn SharedInstance;

    //lista vihollisista unityyn
    public List<GameObject> enemies;
    //peliobjecti unityss‰ mit‰ laitellaan listaan
    public GameObject enemy;
    //m‰‰r‰ on montako vihollisia on peliss‰, hallinoidaan unityss‰
    public int enemiesOnGame;

    //access to player collider script where the difficult level changes
    public CollisionScript collisionScript;

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        //enemies = new List<GameObject>();

        for (int i = 0; i < enemiesOnGame; i++)
        {
            GameObject temp = Instantiate(enemy);
            temp.SetActive(false);
            enemies.Add(temp);
        }

        InvokeRepeating(nameof(SpawnRepeat), 2f, 0.8f);
    }

    public void SpawnRepeat()
    {
        if(collisionScript.difficultLevel == 1)
        {
            GameObject localEnemy = GetPooledObject();

            if (localEnemy != null)
            {
                localEnemy.transform.position = (spawner[Random.Range(0, 1)].transform.position);
                localEnemy.transform.rotation = (spawner[Random.Range(0, 1)].transform.rotation);
                localEnemy.SetActive(true);
            }
        }

        if (collisionScript.difficultLevel == 2)
        {
            GameObject localEnemy = GetPooledObject();

            if (localEnemy != null)
            {
                localEnemy.transform.position = (spawner[Random.Range(0, 2)].transform.position);
                localEnemy.transform.rotation = (spawner[Random.Range(0, 2)].transform.rotation);
                localEnemy.SetActive(true);
            }
        }

        if (collisionScript.difficultLevel == 3)
        {
            GameObject localEnemy = GetPooledObject();

            if (localEnemy != null)
            {
                localEnemy.transform.position = (spawner[Random.Range(0, 4)].transform.position);
                localEnemy.transform.rotation = (spawner[Random.Range(0, 4)].transform.rotation);
                localEnemy.SetActive(true);
            }
        }

        if (collisionScript.difficultLevel == 4)
        {
            GameObject localEnemy = GetPooledObject();

            if (localEnemy != null)
            {
                localEnemy.transform.position = (spawner[Random.Range(0, 6)].transform.position);
                localEnemy.transform.rotation = (spawner[Random.Range(0, 6)].transform.rotation);
                localEnemy.SetActive(true);
            }
        }

        if (collisionScript.difficultLevel == 5)
        {
            GameObject localEnemy = GetPooledObject();

            if (localEnemy != null)
            {
                localEnemy.transform.position = (spawner[Random.Range(0, 8)].transform.position);
                localEnemy.transform.rotation = (spawner[Random.Range(0, 8)].transform.rotation);
                localEnemy.SetActive(true);
            }
        }


    }

    public GameObject GetPooledObject()
    {

        for (int i = 0; i < enemiesOnGame; i++)
        {
            if (!enemies[i].activeInHierarchy)
            {
                return enemies[i];
            }
        }
        return null;
    }
}
