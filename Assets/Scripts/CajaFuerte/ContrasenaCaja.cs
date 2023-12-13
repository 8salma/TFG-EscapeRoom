using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrasenaCaja : MonoBehaviour
{
    [Header("Variables para la puerta")]
    public GameObject puerta;
    private float velocidad = 1f;

    [Header("Ruedas de la caja")]
    public GameObject switch1;
    public GameObject switch2;
    public GameObject switch3;
    public GameObject switch4;

    [Header("Contraseña correcta")]
    private int[] password = new int[4];

    [Header("variables de control")]
    private bool desbloqueado = false;

    // Start is called before the first frame update
    void Start()
    {
        password[0] = 4;
        password[1] = 4;
        password[2] = 3;
        password[3] = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (switch1.GetComponent<Dimmer>().numeroActual == password[0]
        && switch2.GetComponent<Dimmer>().numeroActual == password[1]
        && switch3.GetComponent<Dimmer>().numeroActual == password[2]
        && switch4.GetComponent<Dimmer>().numeroActual == password[3]
        && !desbloqueado)
        {
            Quaternion targetRotation = Quaternion.Euler(-90f,0f, 105f);
            puerta.transform.localRotation = Quaternion.Slerp(puerta.transform.localRotation, targetRotation, velocidad * Time.deltaTime);

            // desbloqueado = true;
        }

    }
}