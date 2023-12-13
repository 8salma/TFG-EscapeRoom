using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    public Vector3[] estados = new Vector3[3];

    public int cambio = 0;
    public GameObject[] luces = new GameObject[3];
    public Material[] material = new Material[3];
    public GameObject diodo;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void cambiarEstado()
    {
        cambio++;
        if (cambio == 3)
        {
            cambio = 0;
        }

        // cambio posicion
        transform.localEulerAngles = estados[cambio];

        // cambio luces y material
        luces[cambio].SetActive(true);
        diodo.GetComponent<Renderer>().material = material[cambio];
        
        if (cambio == 0)
        {
            luces[2].SetActive(false);
        }
        else
        {
            luces[cambio - 1].SetActive(false);
        }
    }
}
