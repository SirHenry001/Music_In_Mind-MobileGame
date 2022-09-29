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

        InvokeRepeating(nameof(SpawnRepeat), 3f, 0.5f);
    }

    public void SpawnRepeat()
    {

        GameObject localEnemy = EnemySpawn.SharedInstance.GetPooledObject();

        if (localEnemy != null)
        {
            localEnemy.transform.position = (spawner[Random.Range(0, 5)].transform.position);
            localEnemy.transform.rotation = (spawner[Random.Range(0, 5)].transform.rotation);
            localEnemy.SetActive(true);
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
