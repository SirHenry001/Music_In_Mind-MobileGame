using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAmmo : MonoBehaviour
{
    public float ammoSpeed;
    public float timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }

    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= 1)
        {
            gameObject.SetActive(false);
            timer = 0;
        }

        transform.Translate(Vector2.up * ammoSpeed * Time.deltaTime);
    }
}
