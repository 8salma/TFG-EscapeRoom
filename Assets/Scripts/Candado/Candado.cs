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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Modo interacción con candado con click izquierdo
        if (activa)
        {
            entrar();
        }

        // Salir con Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            salir();
        }
    }

    public void entrar()
    {
        // Cambio de cámara
        camaraCandado.SetActive(true);
        camaraJugador.SetActive(false);

        // controladorCamara.GetComponent<CambiosCamara>().camaraNevera();

        // hacemos visible el cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Bloquear movimiento del jugador
        player.GetComponent<PlayerController>().bloquear = true;

        activa = false;
    }
    public void salir()
    {
        // Cambio de cámara
        camaraCandado.SetActive(false);
        camaraJugador.SetActive(true);

        // hacemos invisible el cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Desbloquear movimiento del jugador
        player.GetComponent<PlayerController>().bloquear = false;
    }

}
