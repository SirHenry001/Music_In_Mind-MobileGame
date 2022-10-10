using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public GameObject[] spawner;

    //lista pickupia unityyn
    public List<GameObject> enemies;

    //peliobjecti unityss‰ mit‰ laitellaan listaan
    public GameObject pickup;

    //m‰‰r‰ on montako pickupia on peliss‰, hallinoidaan unityss‰
    public int pickupsOnGame;


    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

        //enemies = new List<GameObject>();

        for (int i = 0; i < pickupsOnGame; i++)
        {
            GameObject temp = Instantiate(pickup);
            temp.SetActive(false);
            enemies.Add(temp);
        }

        InvokeRepeating(nameof(SpawnRepeat), 3f, 1f);
    }

    public void SpawnRepeat()
    {

        GameObject localPickUp = GetPooledObject();

        if (localPickUp != null)
        {
            localPickUp.transform.position = (spawner[Random.Range(0, 4)].transform.position);
            localPickUp.transform.rotation = (spawner[Random.Range(0, 4)].transform.rotation);
            localPickUp.SetActive(true);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pickupsOnGame; i++)
        {
            if (!enemies[i].activeInHierarchy)
            {
                return enemies[i];
            }
        }

        return null;



    }
}
