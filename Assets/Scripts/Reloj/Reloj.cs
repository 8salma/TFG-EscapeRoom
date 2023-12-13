using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *   Scrip encargado de controlar el cambio de cámara para la nevera
 *   Gestiona el entrar en "modo nevera" con triggers
 */

public class Reloj : MonoBehaviour
{
    public bool activa;
    public GameObject camaraReloj;
    public GameObject camaraJugador;
    // public GameObject controladorCamara;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Modo arrastrar imanes con click izquierdo
        if (activa)
        {
            // Cambio de cámara
            camaraReloj.SetActive(true);
            camaraJugador.SetActive(false);

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
            camaraReloj.SetActive(false);
            camaraJugador.SetActive(true);

            // hacemos invisible el cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // Desbloquear movimiento del jugador
            player.GetComponent<PlayerController>().bloquear = false;

            activa = false;
        }
    }

    /*
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Papaya")
            {
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
        */
}
