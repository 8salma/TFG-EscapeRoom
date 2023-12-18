using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrasenaCandado : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;

    [Header("Ruedas del candado")]
    public GameObject switch1;
    public GameObject switch2;
    public GameObject switch3;
    public GameObject switch4;

    [Header("Contraseña correcta")]
    private int[] password = new int[4];

    [Header("Variables de control")]
    public GameObject tapa;
    bool abierto = false;

    [Header("Variables para abrir el cofre")]
    public float anguloTapaAbierta = -200.0f; // Ángulo de la tapa al estar abierta
    public float anguloTapaCerrada = -90.0f; // Ángulo de la tapa al estar cerrada
    public float velocidad = 3.0f; // Velocidad con la que se abre la tapa

    [Header("Camaras")]
    public GameObject camaraJugador;
    public GameObject camaraCandado;

    // Start is called before the first frame update
    void Start()
    {
        password[0] = 1;
        password[1] = 3;
        password[2] = 6;
        password[3] = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (switch1.GetComponent<SwitchRueda>().numeroActual == password[0]
            && switch2.GetComponent<SwitchRueda>().numeroActual == password[1]
            && switch3.GetComponent<SwitchRueda>().numeroActual == password[2]
            && switch4.GetComponent<SwitchRueda>().numeroActual == password[3]
            && !abierto) // Comprueba si el candado no está abierto
        {
            Debug.Log("CANDADO DESBLOQUEADO");

            StartCoroutine(AbrirCandado());
        }
    }

    IEnumerator AbrirCandado()
    {
        // Indica que ya se está ejecutando la animación de apertura
        abierto = true;

        // salir del modo ver candado
        tapa.GetComponent<Candado>().salir();

        // Se guarda la rotación inicial del candado
        Quaternion initialRotation = tapa.transform.localRotation;

        // Define el ángulo objetivo de rotación (abrir el candado)
        Quaternion targetRotation = Quaternion.Euler(anguloTapaAbierta, 0, 0);

        float elapsedTime = 0f;
        float duration = 1f; // Duración de la animación en segundos

        while (elapsedTime < duration)
        {
            // Incrementa el tiempo transcurrido
            elapsedTime += Time.deltaTime;

            // Aplica una interpolación para la rotación gradual hacia el ángulo objetivo
            tapa.transform.localRotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / duration);

            yield return null; // Espera hasta el siguiente frame
        }

        tapa.tag = "NoCoger";
        tapa.layer = LayerMask.NameToLayer("Ignore Raycast");
    }
}