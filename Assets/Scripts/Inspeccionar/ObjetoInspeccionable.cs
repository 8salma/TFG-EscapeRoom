using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*   Scrip encargado de entrar y salir del modo inspección
*   Asignar a objetos inspeccionables
*/

public class ObjetoInspeccionable : MonoBehaviour
{
    // public GameObject notaVisual;
    public GameObject objVisual;
    public GameObject camaraVisual;
    public GameObject objEnEscena;

    public GameObject player;

    public bool activa;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(0) && activa)
        {
            player.GetComponent<PlayerController>().bloquear = true;
            
            // hacemos visible el cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //notaVisual.SetActive(true);
            objVisual.SetActive(true);
            camaraVisual.SetActive(true);
            objEnEscena.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && activa)
        {
            player.GetComponent<PlayerController>().bloquear = false;

            // hacemos invisible el cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            //notaVisual.SetActive(false);
            objVisual.SetActive(false);
            camaraVisual.SetActive(false);
            objEnEscena.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Alguien ha entrado...");
        Debug.Log(other.tag + "\n");
        if (other.tag == "Papaya")
        {
            activa = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Saliendo...");
        Debug.Log(other.tag + "\n");
        if (other.tag == "Papaya")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            activa = false;
            // notaVisual.SetActive(false);
            objVisual.SetActive(false);
            camaraVisual.SetActive(false);
            objEnEscena.SetActive(true);
        }
    }
}
