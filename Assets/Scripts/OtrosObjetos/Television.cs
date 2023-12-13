using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Television : MonoBehaviour
{
    public GameObject[] videos = new GameObject[4];
    private int sigCanal = 0;
    private bool apagar = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CambioCanal()
    {
        if (apagar)
        {
            videos[sigCanal - 1].SetActive(false);
            apagar = false;
            sigCanal = 0;
        }
        else
        {
            Debug.Log("enciendo tv");
            if (sigCanal != 0)
            {
                videos[sigCanal - 1].SetActive(false);
            }
            videos[sigCanal].SetActive(true);
            sigCanal++;
            if (sigCanal == 3)
            {
                apagar = true;
            }
        }
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Papaya")
        {
            // Debug.Log("Puedo encender pero tengo mando??" + tengoMando);
            activa = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Papaya")
        {
            activa = false;
        }
    }

    private void Encender()
    {
        encendido = true;
        pantalla.SetActive(true);
    }

    private void Apagar()
    {
        encendido = false;
        pantalla.SetActive(false);
    }
    */
}
