using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*   Scrip encargado de comprobar si el jugador tiene llave para abrir la puerta
*   Cambiar el estado de la puerta segun la llave
*/

public class PuertaCerrada : MonoBehaviour
{
    bool activa;
    bool tengoLlave;
    string tagLlave;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tengoLlave = player.GetComponent<PlayerController>().tengoLlave;
        tagLlave = player.GetComponent<PlayerController>().tagLlave;

        if (Input.GetMouseButton(0) && activa && tengoLlave && tagLlave == gameObject.transform.tag)
        {
            gameObject.GetComponent<Puerta>().ChangeDoorState();

            // una vez desbloqueada, hacemos que sea una puerta normal
            gameObject.tag = "Door";
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Papaya")
        {
            Debug.Log("Dentro, llave? " + tengoLlave);
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
