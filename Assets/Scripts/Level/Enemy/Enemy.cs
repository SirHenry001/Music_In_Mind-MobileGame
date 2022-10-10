using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public AudioManager audioManager;
    public MusicManager musicManager;

    public float speed;
    public float hittedSpeed;

    public GameObject effectParticles;

    public Transform target;
    public Rigidbody2D myRigidbody;
    public bool isHitted;

    public Vector2 movement;
    public Vector2 fleeing;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(effectParticles, transform.position, transform.rotation);
            audioManager.PlayAudio(2);
            isHitted = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        musicManager = GameObject.Find("MusicPlayer").GetComponent<MusicManager>();
        target = GameObject.Find("HeroCharacter").transform;
        myRigidbody = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(!isHitted)
        {
            Vector2 direction = target.position - transform.position;
            direction.Normalize();
            movement = direction;

            Approach(movement);
        }

        if (isHitted)
        {
            Flee();
        }

    }

    void Approach(Vector2 direction)
    {
        myRigidbody.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    void Flee()
    {
        myRigidbody.AddForce(transform.up * hittedSpeed);
        gameObject.SetActive(false);
        isHitted = false;
    }

}
