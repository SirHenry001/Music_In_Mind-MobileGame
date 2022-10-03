using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMax : MonoBehaviour
{

    public CollisionScript collisionScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")

        {
            collisionScript.Score(200);
            collisionScript.AddTime(100);
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
