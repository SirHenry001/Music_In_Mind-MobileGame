using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float intervalTime;
    public float timer;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        timer += Time.deltaTime;

        if(timer > intervalTime)
        {
            speed = -speed;
            timer = 0;
        }

    }
}
