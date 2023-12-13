using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*   Scrip encargado la rotacion de la puerta
*   Cambia el estado de la puerta (abierta o cerrada) y la rota
*/

public class Puerta : MonoBehaviour
{

    public bool puertaAbierta = false; // Verifica si la puerta está abierta o cerrada
    public float anguloPuertaAbierta = 95.0f; // Ángulo de la puerta al estar abierta
    public float anguloPuertaCerrada = 0.0f; // Ángulo de la puerta al estar cerrada
    public float smooth = 3.0f; // Velocidad con la que se abre la puerta

    void Start()
    {

    }

    void Update()
    {
        if (puertaAbierta)
        {
            Quaternion targetRotation = Quaternion.Euler(0, anguloPuertaAbierta, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, anguloPuertaCerrada, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smooth * Time.deltaTime);
        }
    }

    public void ChangeDoorState()
    {
        puertaAbierta = !puertaAbierta;
    }
}
