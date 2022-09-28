using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{

    public float power;

    public void Shoot()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * power * 1000f); 
    }
}
