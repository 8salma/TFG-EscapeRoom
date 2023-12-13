using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonesLaptop : MonoBehaviour
{
    [Header("Objetos necesarios")]
    [SerializeField]
    private GameObject portatil;
    public GameObject fallo;
    [SerializeField]
    private GameObject canvasPortatil;
    [SerializeField]
    private GameObject canvasSecreto;
    [SerializeField]
    private GameObject player;

    public InputField inputField;

    GameObject camaraLap, camaraJugador;

    // Contraseña correcta
    private string passCorrecta = "H632P";
    private string passCorrecta2 = "h632p";

    public void AceptarButton()
    {
        Debug.Log(inputField.text);
        if (inputField.text == passCorrecta || inputField.text == passCorrecta2)
        {
            portatil.GetComponent<Laptop>().haAcertado = true;
            canvasPortatil.SetActive(false);
            canvasSecreto.SetActive(true);
        }
        else
        {
            fallo.SetActive(true);
            inputField.text = "";
        }
    }

    public void SalirButton()
    {
        portatil.GetComponent<Laptop>().salgo();
    }
}
