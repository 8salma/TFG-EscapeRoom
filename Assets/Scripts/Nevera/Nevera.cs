using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *   Scrip encargado de controlar el cambio de cámara para la nevera
 *   Gestiona el entrar en "modo nevera" con triggers
 */

public class Nevera : MonoBehaviour
{
    public bool activa;
    public GameObject camaraNevera;
    public GameObject camaraJugador;
    public GameObject mover;
    public GameObject salir;
    public GameObject interactuar;

    // public GameObject controladorCamara;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Salir con Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Cambio de cámara
            camaraNevera.SetActive(false);
            camaraJugador.SetActive(true);

            // hacemos invisible el cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // Desbloquear movimiento del jugador
            player.GetComponent<PlayerController>().bloquear = false;

            activa = false;
        }
    }

    public void entrar()
    {
        // Cambio de cámara
        camaraNevera.SetActive(true);
        camaraJugador.SetActive(false);

        // Cambios del canvas
        mover.SetActive(true);
        salir.SetActive(true);
        interactuar.SetActive(false);

        // controladorCamara.GetComponent<CambiosCamara>().camaraNevera();

        // hacemos visible el cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Bloquear movimiento del jugador
        player.GetComponent<PlayerController>().bloquear = true;
    }
}
