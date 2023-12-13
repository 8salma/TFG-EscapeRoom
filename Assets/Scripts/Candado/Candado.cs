using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candado : MonoBehaviour
{
    public bool activa;
    public GameObject camaraCandado;
    public GameObject camaraJugador;
    // public GameObject controladorCamara;
    public GameObject player;
    public GameObject interactuar;
    public GameObject salir;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Modo interacción con candado con click izquierdo
        if (Input.GetMouseButton(0) && activa)
        {
            // Cambio de cámara
            camaraCandado.SetActive(true);
            camaraJugador.SetActive(false);

            // Cambios del canvas
            interactuar.SetActive(true);
            salir.SetActive(true);

            // controladorCamara.GetComponent<CambiosCamara>().camaraNevera();

            // hacemos visible el cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Bloquear movimiento del jugador
            player.GetComponent<PlayerController>().bloquear = true;
        }

        // Salir con Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Cambio de cámara
            camaraCandado.SetActive(false);
            camaraJugador.SetActive(true);

            // hacemos invisible el cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // Cambios del canvas
            interactuar.SetActive(false);
            salir.SetActive(false);

            // Desbloquear movimiento del jugador
            player.GetComponent<PlayerController>().bloquear = false;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("candao sii");
        if (other.tag == "Papaya")
        {
            activa = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("candao noo");

        if (other.tag == "Papaya")
        {
            activa = false;
        }
    }
}
