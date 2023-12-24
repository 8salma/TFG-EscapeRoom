using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *   Controla cambio de cámara para ajedrez
 *   Mete las piezas en el tablero
 */

public class Ajedrez : MonoBehaviour
{
    [Header("Control para la entrada")]
    public bool activa;

    [Header("Cámaras")]
    public GameObject camaraAjedrez;
    public GameObject camaraJugador;

    [Header("Objetos")]
    public GameObject player;
    public GameObject ajedrez;
    private GameObject pieza;

    // numero de piezas que voy metiendo
    private int puesto = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activa)
        {
            entrar();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            salir();
        }
    }

    public void entrar()
    {
        // si tengo pieza, la deja en el tablero
        if (player.GetComponent<PlayerController>().tengoPieza)
        {
            pieza = camaraJugador.GetComponent<PickUp>().objeto;

            // emparentar pieza con el tablero
            pieza.transform.parent = ajedrez.transform;

            // devolvemos gravedad y colliders
            foreach (var c in pieza.GetComponentsInChildren<Collider>())
            {
                if (c != null)
                {
                    c.enabled = true;
                }
            }

            foreach (var r in pieza.GetComponentsInChildren<Rigidbody>())
            {
                if (r != null)
                {
                    r.isKinematic = false;
                }
            }

            // posicionar en el tablero
            pieza.transform.localPosition = new Vector3(8f, 0f, puesto);
            pieza.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            puesto++;

            // habilitar drag
            pieza.GetComponent<Piezas>().enTablero = true;

            // soltar pieza
            player.GetComponent<PlayerController>().tengoPieza = false;
            camaraJugador.GetComponent<PickUp>().cogido = false;

            // cambio tags
            pieza.tag = "drag";
            pieza.layer = LayerMask.NameToLayer("Default");

            pieza.transform.GetComponent<Rigidbody>().isKinematic = true;

            // ajustar escala
            pieza.transform.localScale = new Vector3(100f, 100f, 100f);

            activa = false;
        }

        // si no tengo pieza, entro en el modo de visión del tablero
        else
        {
            // Cambio de cámara
            camaraAjedrez.SetActive(true);
            camaraJugador.SetActive(false);

            // controladorCamara.GetComponent<CambiosCamara>().camaraAjedrez();

            // hacemos visible el cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Bloquear movimiento del jugador
            player.GetComponent<PlayerController>().bloquear = true;

            activa = false;
        }
    }

    // Salir del modo de visión del tablero
    public void salir()
    {
        // Cambio de cámara
        camaraAjedrez.SetActive(false);
        camaraJugador.SetActive(true);

        // hacemos invisible el cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Desbloquear movimiento del jugador
        player.GetComponent<PlayerController>().bloquear = false;
    }
}
