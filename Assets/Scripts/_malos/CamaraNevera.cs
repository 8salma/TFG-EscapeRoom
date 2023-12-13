using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraNevera : MonoBehaviour
{
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Coger();
        }
        if (Input.GetMouseButton(1))
        {

        }
    }

    void Coger()
    {
        // Raycast según las posición del mouse
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        // Pintar rayo
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "drag")
            {
                Debug.Log("Toco Iman");
            }
        }
    }
}
