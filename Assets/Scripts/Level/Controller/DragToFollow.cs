using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragToFollow : MonoBehaviour
{

    public GameObject target;
    public float followSpeed;

    public LayerMask layerMask;

    private void Start()
    {
        print("Game On!");
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity,layerMask))
        {
            //Seuraa suoraan sormea samassa kohdassa
            //target.transform.position = hit.point;

            //seuraa sormea hieman viiveellä
            target.transform.position = Vector3.Lerp(target.transform.position, hit.point, followSpeed * Time.deltaTime);
        }

    }
}