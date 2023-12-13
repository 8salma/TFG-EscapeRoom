using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *   Scrip encargado de controlar el cambio de cámara para el ajedrez
 *   Gestiona el entrar en "modo ajedrez" con triggers
 */

public class Ajedrez : MonoBehaviour
{
    public bool activa;
    public GameObject camaraAjedrez;
    public GameObject camaraJugador;
    public GameObject mover;
    public GameObject salir;
    public GameObject soltar;
    public GameObject interactuar;
    // public GameObject controladorCamara;
    public GameObject player;
    public GameObject ajedrez;
    private GameObject pieza;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && activa)
        {
            entrar();
        }
        // Salir con Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            salgo();
        }
    }

    public void entrar()
    {
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
            pieza.transform.localPosition = new Vector3(8f, 0f, 1f);
            pieza.transform.localEulerAngles = new Vector3(0f, 0f, 0f);

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
        }
        else
        {
            // Cambio de cámara
            camaraAjedrez.SetActive(true);
            camaraJugador.SetActive(false);

            // cambios canvas
            mover.SetActive(true);
            salir.SetActive(true);
            interactuar.SetActive(false);
            soltar.SetActive(false);

            // controladorCamara.GetComponent<CambiosCamara>().camaraAjedrez();

            // hacemos visible el cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Bloquear movimiento del jugador
            player.GetComponent<PlayerController>().bloquear = true;
        }
    }

    public void salgo()
    {
        // Cambio de cámara
        camaraAjedrez.SetActive(false);
        camaraJugador.SetActive(true);

        mover.SetActive(false);
        salir.SetActive(false);

        // hacemos invisible el cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Desbloquear movimiento del jugador
        player.GetComponent<PlayerController>().bloquear = false;
    }

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
}
