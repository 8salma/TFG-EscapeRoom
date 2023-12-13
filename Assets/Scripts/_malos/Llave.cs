using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// creo que esto no hace nada
public class Llave : MonoBehaviour
{

    public GameObject Objetollave;
    public GameObject ColliderPuerta;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ColliderPuerta.gameObject.SetActive(true);
            Destroy(Objetollave);
        }
    }
}
