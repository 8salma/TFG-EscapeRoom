using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiosCamara : MonoBehaviour
{
    public GameObject vistaNevera;
    public GameObject vistaLaptop;
    float velocidad;
    Transform currentView;

    // Start is called before the first frame update
    void Start()
    {
        currentView = transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void camaraNevera()
    {
        currentView = vistaNevera.transform;
    }

    public void camaraLaptop()
    {
        currentView = vistaLaptop.transform;
    }

    private void LatedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * velocidad);
    }
}
