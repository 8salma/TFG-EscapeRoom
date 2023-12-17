using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour
{
    // Variable para controlar la entrada y salida al trigger
    public bool activa;

    [Header("Objetos necesarios")]
    public GameObject camaraLap;
    public GameObject camaraJugador;
    public GameObject player;
    public GameObject canvasPortatil;
    public GameObject canvasSecreto;
    public GameObject canvasPrincipal;
    public GameObject fallo;

    // Otras variables de control
    bool dentroPortatil = false;
    public bool haAcertado = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Modo ver portatil con clic izquierdo
        if (activa && !dentroPortatil)
        {
            if (!haAcertado)
            {
                entrarPortatil();
            }
            else
            {
                entrarSecreto();
            }
        }

        // Salir con Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            salgo();
        }
    }

    private void entrarPortatil()
    {
        // Cambio de cámara
        camaraLap.SetActive(true);
        camaraJugador.SetActive(false);

        // hacemos visible el cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // activamos canvas del portatil
        canvasPortatil.SetActive(true);

        fallo.SetActive(false);

        // Bloquear movimiento del jugador
        player.GetComponent<PlayerController>().bloquear = true;

        // Cambiamos la variable de control
        dentroPortatil = true;
    }

    private void entrarSecreto()
    {
        // Cambio de cámara
        camaraLap.SetActive(true);
        camaraJugador.SetActive(false);

        // hacemos visible el cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // activamos canvas secreto
        canvasSecreto.SetActive(true);
        canvasPrincipal.SetActive(false);

        // Bloquear movimiento del jugador
        player.GetComponent<PlayerController>().bloquear = true;

        // Cambiamos la variable de control
        dentroPortatil = true;
    }

    private void contrasenaCorrecta()
    {
        canvasPortatil.SetActive(false);
        canvasSecreto.SetActive(true);
    }

    public void salgo()
    {
        // Cambio de cámara
        camaraLap.SetActive(false);
        camaraJugador.SetActive(true);

        // hacemos invisible el cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // desactivamos canvas del portatil
        canvasPortatil.SetActive(false);
        canvasSecreto.SetActive(false);
        canvasPrincipal.SetActive(true);

        // Desbloquear movimiento del jugador
        player.GetComponent<PlayerController>().bloquear = false;

        // Cambiamos la variables de control
        dentroPortatil = false;

        activa = false;
    }
}
