using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/*
 *   Interacciones con el raycasta del jugador
 *   objetos que se cogen (mando tv, llaves, piezas, otros)
 *   tambien comprueba puertas y cajones
 */
public class PickUp : MonoBehaviour
{
    [Header("Objetos")]
    public GameObject player;
    public GameObject objeto;
    public GameObject jarron;

    [Header("Cámaras")]
    public GameObject camaraInspeccion;
    public GameObject camaraPlayer;

    [Header("Canvas")]
    public GameObject interactuar;
    public GameObject soltar;

    [Header("Inspección")]
    private GameObject objetoInspeccion;
    public bool inspeccionando;

    [Header("Variables para el raycast")]
    RaycastHit hit;
    public float distancia = 10f;
    public bool cogido = false;

    [Header("Outline objeto")]
    private Transform highlight;
    private Transform selection;

    // Start is called before the first frame update
    void Start()
    {
        objeto = null;
        objetoInspeccion = null;
        inspeccionando = false;
    }

    // Update is called once per frame
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
            objeto = null;
        }
        if (Input.GetKeyDown("e"))
        {
            Inspeccionar();
        }
        if (Input.GetKeyDown("q") && inspeccionando)
        {
            DejarInspeccion();
            objetoInspeccion = null;
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
            && hit.transform.tag != "Cofre"

            && (hit.transform.gameObject.layer == LayerMask.NameToLayer("ObjetoInteractivo") || hit.transform.gameObject.layer == LayerMask.NameToLayer("Llave"))
            && !cogido)
            {
                soltar.SetActive(true);

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

                else if (hit.transform.tag == "Ingrediente")
                {
                    objeto.transform.localPosition = new Vector3(0.95f, -0.76f, 1.13f);
                    objeto.transform.localEulerAngles = new Vector3(-98.897f, -172.072f, 201.574f);
                }

                cogido = true;
            }

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

            // Entrar en el modo de vista del reloj
            if (hit.collider.tag == "reloj")
            {
                hit.collider.transform.GetComponent<Reloj>().activa = true;
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

            // Romper el jarron
            if (hit.collider.tag == "Jarron")
            {
                // compruebo si tengo el martillo
                if (player.GetComponent<PlayerController>().tengoMartillo)
                {
                    jarron.GetComponent<Jarron>().romper();
                    soltar.SetActive(false);
                    interactuar.SetActive(true);
                }
            }

            // Abrir cofre
            if (hit.collider.tag == "Cofre")
            {
                // compruebo si tengo el mando en la mano, si tengo cambio de canal
                if (objeto != null && objeto.transform.tag == "CerraduraCofre")
                {
                    hit.collider.transform.GetComponent<AbrirCofre>().abrir();
                    soltar.SetActive(false);
                    interactuar.SetActive(true);
                }
            }
        }
    }

    void Soltar()
    {
        objeto.transform.parent = null;
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
        player.GetComponent<PlayerController>().tagLlave = "";

        RaycastHit hitDown;
        Physics.Raycast(transform.position, -Vector3.up, out hitDown);
        // objeto.transform.position = hitDown.point + new Vector3(transform.forward.x, 0, transform.forward.z);
    }

    void Inspeccionar()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, distancia))
        {
            // Deseleccionar();
            // SeleccionarObjeto(hit.transform);

            // He cogido una pieza de ajedrez
            if (hit.transform.tag == "Pieza")
            {
                inspeccionando = true;
                objetoInspeccion = hit.transform.gameObject;

                // emparentar con la cámara
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

                objetoInspeccion.transform.parent = transform;

                // hacemos visible el cursor
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                // Bloquear movimiento del jugador
                player.GetComponent<PlayerController>().bloquear = true;

                objetoInspeccion.GetComponent<InspeccionObjeto>().enabled = true;
            }
        }
    }

    void DejarInspeccion()
    {
        objetoInspeccion.transform.parent = null;
        foreach (var c in objetoInspeccion.GetComponentsInChildren<Collider>())
        {
            if (c != null)
            {
                c.enabled = true;
            }
        }

        foreach (var r in objetoInspeccion.GetComponentsInChildren<Rigidbody>())
        {
            if (r != null)
            {
                r.isKinematic = false;
            }
        }
        // hacemos invisible el cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Desbloquear movimiento del jugador
        player.GetComponent<PlayerController>().bloquear = false;

        inspeccionando = false;
    }


    private void verficarCoger()
    {
        if (!cogido)
        {
            soltar.SetActive(false);
        }
    }
}