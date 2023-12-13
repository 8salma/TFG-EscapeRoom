using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*   Scrip encargado ddel movimiento del objeto con le mouse en el modo inspección
*/

public class Inspeccionar : MonoBehaviour
{
    public float velocidadH;
    public float velocidadV;
    float movimientoH;
    float movimientoV;
    public Camera camara;
    private float zoom = 20f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (camara.orthographic)
        {
            camara.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoom;
        }
        else
        {
            camara.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * zoom;
        }
    }

    void OnMouseDrag()
    {
        movimientoH -= velocidadH * Input.GetAxis("Mouse X");
        movimientoV += velocidadV * Input.GetAxis("Mouse Y");
        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles = new Vector3(-movimientoV, movimientoH, 0f);
        }
    }
}
