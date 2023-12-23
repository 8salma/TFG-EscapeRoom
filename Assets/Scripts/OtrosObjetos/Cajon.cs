using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*   Scrip encargado de cambiar el estado del cajon y moverlo
*   
*/
public class Cajon : MonoBehaviour
{
    [Header("Configuración")]
    public float velocidad;
    public float posCuandoAbre;

    bool abierto = false;
    bool abriendo = false;
    bool cerrando = false;
    Vector3 posAbierto;
    Vector3 posCerrado;

    private AudioSource sonido;

    // Start is called before the first frame update
    void Start()
    {
        posCerrado = transform.localPosition;
        posAbierto = new Vector3(transform.localPosition.x, transform.localPosition.y, posCuandoAbre);
        sonido = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (abriendo)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, posAbierto, Time.deltaTime * velocidad);
            if (Vector3.Distance(transform.localPosition, posAbierto) < 0.0001F)
            {
                abierto = true;
                abriendo = false;
            }
        }

        if (cerrando)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, posCerrado, Time.deltaTime * velocidad);
            if (Vector3.Distance(transform.localPosition, posCerrado) < 0.0001F)
            {
                abierto = false;
                cerrando = false;
            }
        }
    }

    public void AbreCierra()
    {
        if (!abierto)
        {
            abriendo = true;
            sonido.Play();
        }

        else
        {
            cerrando = true;
            sonido.Play();
        }
    }
}
