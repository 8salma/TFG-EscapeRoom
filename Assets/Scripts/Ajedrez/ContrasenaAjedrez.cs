using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrasenaAjedrez : MonoBehaviour
{

    [Header("Jugador")]
    public GameObject player;

    [Header("Ajedrez")]
    public GameObject ajedrez;

    [Header("Cajon")]
    public GameObject cajon;

    public GameObject linea;

    [Header("Camaras")]
    public GameObject camaraAjedrez;
    public GameObject camaraJugador;

    [Header("Canvas")]
    public GameObject mover;
    public GameObject salir;
    public GameObject soltar;
    public GameObject interactuar;

    [Header("Piezas")]
    public GameObject alfilNegro1;
    public GameObject peonBlanco1;
    public GameObject peonBlanco2;
    public GameObject peonNegro1;
    public GameObject reinaBlanca;

    [Header("Variables para abrir cajon")]
    public float velocidad;
    public float posCuandoAbre;
    Vector3 posAbierto;
    Vector3 posCerrado;

    [Header("Variables de control")]
    private bool cajonDesbloqueado = false;

    // Start is called before the first frame update
    void Start()
    {
        posCerrado = cajon.transform.position;
        posAbierto = new Vector3(cajon.transform.localPosition.x, cajon.transform.localPosition.y, posCuandoAbre);
    }

    // Update is called once per frame
    void Update()
    {
        if (!cajonDesbloqueado
        && (alfilNegro1.transform.localPosition == new Vector3(2.0f, 0.0f, 7.0f)
        && ((peonBlanco1.transform.localPosition == new Vector3(4.0f, 0.0f, 2.0f) && peonBlanco2.transform.localPosition == new Vector3(7.0f, 0.0f, 2.0f)) || (peonBlanco2.transform.localPosition == new Vector3(4.0f, 0.0f, 2.0f) && peonBlanco1.transform.localPosition == new Vector3(7.0f, 0.0f, 2.0f)))
        && peonNegro1.transform.localPosition == new Vector3(1.0f, 0.0f, 6.0f)
        && reinaBlanca.transform.localPosition == new Vector3(0.0f, 0.0f, 2.0f)
        ))
        {
            /*
            Debug.Log("AJEDREZ DESBLOQUEADO");

            // SALIMOS DEL MODO AJEDREZ

            // DESBLOQUEO DEL CAJON
            cajon.transform.localPosition = Vector3.MoveTowards(cajon.transform.localPosition, posAbierto, Time.deltaTime * velocidad);

            // triggerAjedrez.GetComponent<Collider>().SetActive(false);
            // linea.GetComponent<OutlineSelection>().enabled = false;
            // Destroy(camaraAjedrez);

            camaraAjedrez.SetActive(false);
            camaraJugador.SetActive(true);

            // hacemos invisible el cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            ajedrez.GetComponent<Ajedrez>().salgo();
            // ya no interactuo con el ajedrez
            ajedrez.GetComponent<BoxCollider>().enabled = false;

            // Desbloquear movimiento del jugador
            player.GetComponent<PlayerController>().bloquear = false;

            //cajonDesbloqueado = true;


*/

            Debug.Log("AJEDREZ DESBLOQUEADO");

            // SALIR MODO CANDADO
            cajon.transform.localPosition = Vector3.MoveTowards(cajon.transform.localPosition, posAbierto, Time.deltaTime * velocidad);

            // Cambio de cámara
            camaraAjedrez.SetActive(false);
            camaraJugador.SetActive(true);

            // hacemos invisible el cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // cambios canvas
            mover.SetActive(false);
            salir.SetActive(false);

            // cambio tags
            ajedrez.tag = "NoCoger";
            ajedrez.layer = LayerMask.NameToLayer("Ignore Raycast");

            // Desbloquear movimiento del jugador
            player.GetComponent<PlayerController>().bloquear = false;

        }
    }

    void desbloquearCajon()
    {

    }
}
