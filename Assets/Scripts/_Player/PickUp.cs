using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/*
 *   Controla el raycast
 *   objetos que se cogen (mando tv, llaves, piezas, otros)
 *   otro tipo de interacción con objetos (puertas, cambios de vista...)
 */
public class PickUp : MonoBehaviour
{
    [Header("Objetos")]
    public GameObject player;
    public GameObject objeto;
    public GameObject puertaNevera;

    [Header("Sonidos")]
    public AudioSource sonidoCoger;
    public AudioSource sonidoSoltar;

    [Header("Canvas")]
    public GameObject interactuar;
    public GameObject soltar;
    public GameObject echar;

    [Header("Variables para el raycast")]
    RaycastHit hit;
    private float distancia = 1.7f;

    [Header("Variables de control para la función COGER")]
    public bool cogido = false;

    [Header("Outline objeto")]
    private Transform highlight;
    private Transform selection;

    [Header("Ticks de ingredientes")]
    public GameObject harina;
    public GameObject leche;
    public GameObject levadura;
    public GameObject huevos;
    public GameObject azucar;

    [Header("Masa")]
    public GameObject masa;

    void Start()
    {
        objeto = null;
    }

    void Update()
    {
        verficarCoger();

        // Highlight
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
            interactuar.SetActive(false);
        }

        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(transform.position, transform.forward, out hit, distancia))
        {
            highlight = hit.transform;
            if ((highlight.gameObject.layer == LayerMask.NameToLayer("ObjetoInteractivo") || highlight.gameObject.layer == LayerMask.NameToLayer("Llave")) && highlight != selection)
            {
                interactuar.SetActive(true);
                if (highlight.gameObject.GetComponent<Outline>() != null)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.white;
                    highlight.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
                }
            }
            else
            {
                highlight = null;
                interactuar.SetActive(false);
            }
        }


        // visualizar el raycast en la escena
        Debug.DrawRay(transform.position, transform.forward * distancia, Color.red);

        if (Input.GetMouseButtonUp(0))
        {
            Coger();
        }
        if (Input.GetKeyDown("q") && cogido)
        {
            Soltar();
        }
    }

    void Coger()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, distancia))
        {
            // Deseleccionar();
            // SeleccionarObjeto(hit.transform);

            // Interacción con objetos que SE COGEN
            if (hit.transform.tag != "Cajon" && hit.transform.tag != "NoCoger" && hit.transform.tag != "PuertaNevera"
            && hit.transform.tag != "Dimmer" && hit.collider.tag != "PuertaMuebleAlto" && hit.collider.tag != "PuertaImanes"
            && hit.transform.tag != "TableroAjedrez" && hit.transform.tag != "Interruptor" && hit.transform.tag != "TV"
            && hit.transform.tag != "Portatil" && hit.transform.tag != "Candado" && hit.transform.tag != "Jarron"
            && hit.transform.tag != "Cofre" && hit.transform.tag != "Nota" && hit.transform.tag != "Cuenco" && hit.transform.tag != "CandadoNevera"

            && (hit.transform.gameObject.layer == LayerMask.NameToLayer("ObjetoInteractivo") || hit.transform.gameObject.layer == LayerMask.NameToLayer("Llave"))
            && !cogido)
            {
                sonidoCoger.Play();
                soltar.SetActive(true);

                // HE COGIDO INGREDIENTE
                // Harina
                if (hit.transform.tag == "Harina")
                {
                    harina.SetActive(true);
                    player.GetComponent<PlayerController>().tengoIngrediente = true;
                }
                // Leche
                if (hit.transform.tag == "Leche")
                {
                    leche.SetActive(true);
                    player.GetComponent<PlayerController>().tengoIngrediente = true;
                }
                // Levadura
                if (hit.transform.tag == "Levadura")
                {
                    levadura.SetActive(true);
                    player.GetComponent<PlayerController>().tengoIngrediente = true;
                }
                // Huevos
                if (hit.transform.tag == "Huevos")
                {
                    huevos.SetActive(true);
                    player.GetComponent<PlayerController>().tengoIngrediente = true;
                }
                // Azúcar
                if (hit.transform.tag == "Azucar")
                {
                    azucar.SetActive(true);
                    player.GetComponent<PlayerController>().tengoIngrediente = true;
                }

                // OTROS
                // He cogido el mando de la tv
                if (hit.transform.tag == "MandoTV")
                {
                    player.GetComponent<PlayerController>().tengoMando = true;
                }

                // He cogido una llave
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Llave"))
                {
                    player.GetComponent<PlayerController>().tengoLlave = true;
                    player.GetComponent<PlayerController>().tagLlave = hit.transform.tag;
                }

                // He cogido una pieza de ajedrez
                if (hit.transform.tag == "Pieza")
                {
                    player.GetComponent<PlayerController>().tengoPieza = true;
                }

                if (hit.transform.tag == "Martillo")
                {
                    player.GetComponent<PlayerController>().tengoMartillo = true;
                }

                if (hit.transform.tag == "Ingrediente")
                {
                    player.GetComponent<PlayerController>().tengoIngrediente = true;
                }

                // Guardamos el objeto codigo
                objeto = hit.transform.gameObject;

                foreach (var c in hit.transform.GetComponentsInChildren<Collider>())
                {
                    if (c != null)
                    {
                        c.enabled = false;
                    }
                }

                foreach (var r in hit.transform.GetComponentsInChildren<Rigidbody>())
                {
                    if (r != null)
                    {
                        r.isKinematic = true;
                    }
                }
                objeto.transform.parent = transform;

                // Colocación del objeto en la mano
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Llave"))
                {
                    objeto.transform.localPosition = new Vector3(0.96f, -0.654f, 1.279f);
                    objeto.transform.localEulerAngles = new Vector3(-88.85201f, 0f, 17.522f);
                    objeto.transform.localScale = new Vector3(176.5799f, 176.5799f, 176.5799f);
                }

                else if (hit.transform.tag == "Pieza")
                {
                    objeto.transform.localPosition = new Vector3(0.82f, -0.42f, 1.04f);
                    objeto.transform.localEulerAngles = new Vector3(-8.729f, -12.549f, 6.638f);
                    objeto.transform.localScale = new Vector3(18f, 18f, 18f);
                }

                else if (hit.transform.tag == "MandoTV")
                {
                    objeto.transform.localPosition = new Vector3(0.82f, -0.42f, 1.04f);
                    objeto.transform.localEulerAngles = new Vector3(-33.086f, 32.262f, 175.814f);
                }

                else if (hit.transform.tag == "Martillo")
                {
                    objeto.transform.localPosition = new Vector3(0.75f, -0.62f, 0.996f);
                    objeto.transform.localEulerAngles = new Vector3(-164.011f, -19.008f, 202.118f);
                }

                else if (hit.transform.tag == "Libro")
                {
                    objeto.transform.localPosition = new Vector3(0.792f, -0.701f, 1.169f);
                    objeto.transform.localEulerAngles = new Vector3(526.559f, 225.28f, -175.118f);
                }

                // INGREDIENTES
                else if (hit.transform.tag == "Leche")
                {
                    objeto.transform.localPosition = new Vector3(0.95f, -0.76f, 1.13f);
                    objeto.transform.localEulerAngles = new Vector3(-98.897f, -172.072f, 201.574f);
                }

                else if (hit.transform.tag == "Harina")
                {
                    objeto.transform.localPosition = new Vector3(0.998f, -0.651f, 1.216f);
                    objeto.transform.localEulerAngles = new Vector3(-165.62f, 36.19899f, -186.669f);
                }

                else if (hit.transform.tag == "Levadura")
                {
                    objeto.transform.localPosition = new Vector3(0.998f, -0.651f, 1.216f);
                    objeto.transform.localEulerAngles = new Vector3(-165.62f, 36.19899f, -186.669f);
                }

                else if (hit.transform.tag == "Azucar")
                {
                    objeto.transform.localPosition = new Vector3(0.998f, -0.651f, 1.216f);
                    objeto.transform.localEulerAngles = new Vector3(-165.62f, 36.19899f, -186.669f);
                }

                else if (hit.transform.tag == "Huevos")
                {
                    objeto.transform.localPosition = new Vector3(0.8897552f, -0.7566124f, 1.137059f);
                    objeto.transform.localEulerAngles = new Vector3(-75.731f, 176.638f, 51.522f);
                }

                cogido = true;
            }

            ///////////////////////////

            // OBJETOS que NO SE COGEN

            // Abrir una puerta sin cerradura
            if (hit.collider.tag == "Door")
            {
                hit.collider.transform.GetComponent<Puerta>().ChangeDoorState();
            }

            // Abrir puerta nevera
            if (hit.collider.tag == "PuertaNevera")
            {
                // compruebo si tengo la llave de la nevera
                if (objeto != null && objeto.transform.tag == "CerraduraNevera")
                {
                    hit.collider.transform.GetComponent<PuertaNevera>().bloqueada = false;

                    // destruimos la llave ya usada
                    Destroy(objeto);
                    objeto = null;
                    player.GetComponent<PlayerController>().tengoLlave = false;
                    cogido = false;
                }
                hit.collider.transform.GetComponent<PuertaNevera>().ChangeDoorState();
            }

            // Abrir puerta nevera
            if (hit.collider.tag == "CandadoNevera")
            {
                // compruebo si tengo la llave de la nevera
                if (objeto != null && objeto.transform.tag == "CerraduraNevera")
                {
                    puertaNevera.GetComponent<PuertaNevera>().bloqueada = false;

                    // destruimos la llave ya usada
                    Destroy(objeto);
                    objeto = null;
                    player.GetComponent<PlayerController>().tengoLlave = false;
                    cogido = false;
                }
                puertaNevera.GetComponent<PuertaNevera>().ChangeDoorState();
            }

            // Abrir puerta mueble arriba en la cocina
            if (hit.collider.tag == "PuertaMuebleAlto")
            {
                // compruebo si tengo la llave del mueble
                if (objeto != null && objeto.transform.tag == "LlaveMueble")
                {
                    // compruebo si estoy en la puerta bloqueada
                    if (hit.collider.transform.GetComponent<PuertaMuebleAlto>().bloqueada)
                    {
                        hit.collider.transform.GetComponent<PuertaMuebleAlto>().bloqueada = false;
                        // destruimos la llave ya usada
                        Destroy(objeto);
                        objeto = null;
                        player.GetComponent<PlayerController>().tengoLlave = false;
                        cogido = false;
                    }
                }
                hit.collider.transform.GetComponent<PuertaMuebleAlto>().ChangeDoorState();
            }

            // Cambio canal TV
            if (hit.collider.tag == "TV")
            {
                // compruebo si tengo el mando en la mano, si tengo cambio de canal
                if (player.GetComponent<PlayerController>().tengoMando)
                {
                    soltar.SetActive(false);
                    interactuar.SetActive(true);
                    Debug.Log("canvas");
                    hit.collider.transform.GetComponent<Television>().CambioCanal();
                }
            }

            // Entrar en el modo de vista de imanes
            if (hit.collider.tag == "PuertaImanes")
            {
                hit.collider.transform.GetComponent<Nevera>().entrar();
                highlight.gameObject.GetComponent<Outline>().enabled = false;
                highlight = null;
            }

            // Entrar en el modo de vista del portatil
            if (hit.collider.tag == "Portatil")
            {
                hit.collider.transform.GetComponent<Laptop>().activa = true;
                highlight.gameObject.GetComponent<Outline>().enabled = false;
                highlight = null;
            }

            // Interaccion con cajon
            if (hit.collider.tag == "Cajon")
            {
                hit.collider.transform.GetComponent<Cajon>().AbreCierra();
            }

            // Interruptores de giro (caja fuerte)
            if (hit.collider.tag == "Dimmer")
            {
                hit.collider.transform.GetComponent<Dimmer>().ChangeDimmerState();
            }

            // Interruptor de luz
            if (hit.collider.tag == "Interruptor")
            {
                hit.collider.transform.GetComponent<Interruptor>().cambiarEstado();
            }

            // Cofre candado
            if (hit.collider.tag == "Cofre")
            {
                hit.collider.transform.GetComponent<Candado>().activa = true;
                highlight.gameObject.GetComponent<Outline>().enabled = false;
                highlight = null;
            }

            // Ajedrez
            if (hit.collider.tag == "TableroAjedrez")
            {
                hit.collider.transform.GetComponent<Ajedrez>().activa = true;
                highlight.gameObject.GetComponent<Outline>().enabled = false;
                highlight = null;
            }

            // Ver nota
            if (hit.collider.tag == "Nota")
            {
                hit.collider.transform.GetComponent<Receta>().activa = true;
                highlight.gameObject.GetComponent<Outline>().enabled = false;
                highlight = null;
            }

            // Sistema Ingredientes
            // Abrir puerta nevera
            if (hit.collider.tag == "Cuenco")
            {
                // compruebo si tengo la llave de la nevera
                if (player.GetComponent<PlayerController>().tengoIngrediente)
                {
                    hit.collider.transform.GetComponent<Cuenco>().contador++;
                    if (hit.collider.transform.GetComponent<Cuenco>().contador == 1)
                    {
                        masa.SetActive(true);
                    }
                    // destruimos el ingrediente
                    Destroy(objeto);
                    objeto = null;
                    player.GetComponent<PlayerController>().tengoIngrediente = false;
                    cogido = false;
                }
            }
        }
    }

    void Soltar()
    {
        float maxDistance = 2f;

        objeto.transform.parent = null;

        // Activa los colliders y desactiva la cinemática del Rigidbody
        foreach (var c in objeto.GetComponentsInChildren<Collider>())
        {
            if (c != null)
            {
                c.enabled = true;
            }
        }

        foreach (var r in objeto.GetComponentsInChildren<Rigidbody>())
        {
            if (r != null)
            {
                r.isKinematic = false;
            }
        }

        cogido = false;

        player.GetComponent<PlayerController>().tengoMando = false;
        player.GetComponent<PlayerController>().tengoLlave = false;
        player.GetComponent<PlayerController>().tengoPieza = false;
        player.GetComponent<PlayerController>().tengoIngrediente = false;
        player.GetComponent<PlayerController>().tagLlave = "";

        // Dispara un rayo desde el centro de la cámara hacia adelante
        Camera mainCamera = Camera.main;
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // Punto central de la pantalla
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // Si el rayo golpea algo en el mundo dentro de la distancia máxima, establece la posición del objeto al punto de impacto
            if (objeto.transform.tag == "Libro")
            {
                objeto.transform.localEulerAngles = new Vector3(90f, 0f, 180f);
                Vector3 newPos = new Vector3(hit.point.x, hit.point.y + 0.15f, hit.point.z);
                objeto.transform.position = newPos;
            }
            else
            {
                objeto.transform.position = hit.point;
            }
        }
        else
        {
            // Si no hay impacto dentro de la distancia máxima, establece la posición del objeto al final del rayo
            objeto.transform.position = ray.GetPoint(maxDistance);
        }

        objeto = null;
    }

    private void verficarCoger()
    {
        if (!cogido)
        {
            soltar.SetActive(false);
            // echar.SetActive(false);
        }
    }
}