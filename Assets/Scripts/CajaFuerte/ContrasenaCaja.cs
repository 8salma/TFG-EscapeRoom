using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *   Controlador contraseña caja fuerte
 */

public class ContrasenaCaja : MonoBehaviour
{
    [Header("Variables para la puerta")]
    public GameObject puerta;
    private float velocidad = 1f;

    [Header("Ruedas de la caja")]
    public GameObject switch1;
    public GameObject switch2;
    public GameObject switch3;
    public GameObject switch4;

    [Header("Contraseña correcta")]
    private int[] password = new int[4];

    [Header("Variables de control")]
    private bool desbloqueado = false;

    void Start()
    {
        password[0] = 4;
        password[1] = 4;
        password[2] = 3;
        password[3] = 1;
    }

    void Update()
    {
        if (switch1.GetComponent<Dimmer>().numeroActual == password[0]
        && switch2.GetComponent<Dimmer>().numeroActual == password[1]
        && switch3.GetComponent<Dimmer>().numeroActual == password[2]
        && switch4.GetComponent<Dimmer>().numeroActual == password[3]
        && !desbloqueado)
        {
            StartCoroutine(AbrirCaja());
        }

    }

    IEnumerator AbrirCaja()
    {
        // Indica que ya se está ejecutando la animación de apertura
        desbloqueado = true;

        // Define el ángulo objetivo de rotación (abrir el candado)
        Quaternion targetRotation = Quaternion.Euler(-90f, 0f, 105f);

        float elapsedTime = 0f;
        float duration = 10f; // Duración de la animación en segundos

        while (elapsedTime < duration)
        {
            // Incrementa el tiempo transcurrido
            elapsedTime += Time.deltaTime;

            puerta.transform.localRotation = Quaternion.Slerp(puerta.transform.localRotation, targetRotation, elapsedTime / duration);
            yield return null; // Espera hasta el siguiente frame
        }

    }
}