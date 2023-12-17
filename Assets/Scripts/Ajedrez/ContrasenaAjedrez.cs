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
        if ((alfilNegro1.transform.localPosition == new Vector3(2.0f, 0.0f, 7.0f)
            && ((peonBlanco1.transform.localPosition == new Vector3(4.0f, 0.0f, 2.0f) && peonBlanco2.transform.localPosition == new Vector3(7.0f, 0.0f, 2.0f)) || (peonBlanco2.transform.localPosition == new Vector3(4.0f, 0.0f, 2.0f) && peonBlanco1.transform.localPosition == new Vector3(7.0f, 0.0f, 2.0f)))
            && peonNegro1.transform.localPosition == new Vector3(1.0f, 0.0f, 6.0f)
            && reinaBlanca.transform.localPosition == new Vector3(0.0f, 0.0f, 2.0f)
            && !cajonDesbloqueado))
        {
            Debug.Log("AJEDREZ DESBLOQUEADO");

            StartCoroutine(AbrirCajon());
        }
    }

    IEnumerator AbrirCajon()
    {
        cajonDesbloqueado = true;

        Vector3 initialPosition = cajon.transform.localPosition;
        float elapsedTime = 0f;
        float duration = 1f; // Duración de la animación en segundos
        Vector3 targetPosition = posAbierto; // Definir la posición objetivo del cajón abierto

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // Interpolar gradualmente la posición del cajón hacia el objetivo
            cajon.transform.localPosition = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / duration);

            yield return null; // Esperar al siguiente frame
        }

        // salir del modo ver tablero
        ajedrez.GetComponent<Ajedrez>().salir();

        // Cambiar tags y capas
        ajedrez.tag = "NoCoger";
        ajedrez.layer = LayerMask.NameToLayer("Ignore Raycast");
    }
}
