using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receta : MonoBehaviour
{
    public bool activa;
    public GameObject camaraNota;
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
        if (activa)
        {
            // Cambio de cámara
            camaraNota.SetActive(true);
            camaraJugador.SetActive(false);

            // Bloquear movimiento del jugador
            player.GetComponent<PlayerController>().bloquear = true;

            activa = false;
        }

        // Salir con Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Cambio de cámara
            camaraNota.SetActive(false);
            camaraJugador.SetActive(true);

            // Desbloquear movimiento del jugador
            player.GetComponent<PlayerController>().bloquear = false;
        }
    }
}
