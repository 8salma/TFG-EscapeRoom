using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    LayerMask mask;
    public float distancia = 1.5f;

    public Texture2D puntero;
    GameObject ultimoReconocido = null;
    private bool objetoCogido = false;
    private RaycastHit hit; // Definir hit a nivel global.

    void Start()
    {
        mask = LayerMask.GetMask("Raycast Detect");

    }

    void Update()
    {
        // visualizar el raycast en la escena
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.red);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, mask))
        {
            Deseleccionar();
            SeleccionarObjeto(hit.transform);

            if (objetoCogido == true && Input.GetKey(KeyCode.E))
            {
                objetoCogido = false;
                hit.collider.transform.GetComponent<ObjetoInteractivo>().SoltarObjeto();
            }
            // no tengo ningún objeto en la mano

            // coger con click izquierdo
            if (objetoCogido == false && hit.collider.tag == "Objeto" && Input.GetMouseButtonDown(0))
            {
                objetoCogido = true;
                hit.collider.transform.GetComponent<ObjetoInteractivo>().CogerObjeto();
            }

            // Interaccion con puerta
            if (hit.collider.tag == "Door")
            {
                Debug.Log("Entro puerta");
                if (Input.GetMouseButtonDown(0))
                {
                    hit.collider.transform.GetComponent<Puerta>().ChangeDoorState();
                }
            }
        }
        else
        {
            Deseleccionar();
        }
    }

    void SeleccionarObjeto(Transform transform)
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.green;
        ultimoReconocido = transform.gameObject;
    }

    void Deseleccionar()
    {
        if (ultimoReconocido)
        {
            ultimoReconocido.GetComponent<Renderer>().material.color = Color.white;
            ultimoReconocido = null;
        }
    }

    private void OnGUI()
    {
        Rect rect = new Rect(Screen.width / 2, Screen.height / 2, puntero.width, puntero.height);
        GUI.DrawTexture(rect, puntero);


    }
}
