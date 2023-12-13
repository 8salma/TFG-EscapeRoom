using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*   Scrip encargado la rotacion de la puerta
*   Cambia el estado de la puerta (abierta o cerrada) y la rota
*/

public class PuertaMuebleAlto : MonoBehaviour
{
    public bool puertaAbierta = false; // Verifica si la puerta está abierta o cerrada
    public float anguloPuertaAbierta = 90f; // Ángulo de la puerta al estar abierta
    private float anguloPuertaCerrada = 0f; // Ángulo de la puerta al estar cerrada
    private float velocidad = 3.0f; // Velocidad con la que se abre la puerta
    public bool bloqueada = true;
    public GameObject cerradura;


    void Start()
    {

    }

    void Update()
    {
        if (!bloqueada)
        {
            Destroy(cerradura);
            if (puertaAbierta)
            {
                Quaternion targetRotation = Quaternion.Euler(0.0f, anguloPuertaAbierta, 0.0f);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, velocidad * Time.deltaTime);
            }
            else
            {
                Quaternion targetRotation2 = Quaternion.Euler(0.0f, anguloPuertaCerrada, 0.0f);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, velocidad * Time.deltaTime);
            }
        }
    }

    public void ChangeDoorState()
    {
        puertaAbierta = !puertaAbierta;
    }
}
