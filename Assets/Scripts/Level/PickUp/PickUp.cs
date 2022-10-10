using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public CollisionScript collisionScript;
    public AudioManager audioManager;

    public GameObject effectParticles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")

        {
            collisionScript.Score(100);
            collisionScript.AddTime(50);
            gameObject.SetActive(false);
            Instantiate(effectParticles, transform.position, transform.rotation);
            audioManager.PlayAudio(0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        collisionScript = GameObject.Find("HeroCharacter").GetComponent<CollisionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
