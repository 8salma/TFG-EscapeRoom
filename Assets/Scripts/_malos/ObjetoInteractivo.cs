using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInteractivo : MonoBehaviour
{
     public GameObject handPoint;

    public void CogerObjeto()
    {
        /*
        // Para que el objeto no se "caiga" de la mano
        other.GetComponent<Rigidbody>().useGravity = false;
        other.GetComponent<Rigidbody>().isKinematic = true;

        // Para que siga la posicion del jugador
        other.transform.position = handPoint.transform.position;
        other.gameObject.transform.SetParent(handPoint.gameObject.transform);

        // Cambiamos la referencia del objeto cogido
        pickedObject = other.gameObject;
        */

        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;

        gameObject.transform.position = handPoint.transform.position;
        gameObject.transform.SetParent(handPoint.gameObject.transform);
    }

    public void SoltarObjeto()
    {
        /*
        pickedObject.GetComponent<Rigidbody>().useGravity = true;
        pickedObject.GetComponent<Rigidbody>().isKinematic = false;
        pickedObject.gameObject.transform.SetParent(null);
        pickedObject = null;
        */

        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.gameObject.transform.SetParent(null);

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
