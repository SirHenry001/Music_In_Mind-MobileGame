using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public CollisionScript collisionScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")

        {
            collisionScript.Score1();
            collisionScript.AddTime(10);
            gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        collisionScript = GameObject.Find("HeroCharacter").GetComponent<CollisionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
