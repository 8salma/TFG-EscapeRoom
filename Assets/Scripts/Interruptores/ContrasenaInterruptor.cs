using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrasenaInterruptor : MonoBehaviour
{
    public GameObject switch1;
    public GameObject switch2;
    public GameObject switch3;
    public GameObject luzSecreta;
    public GameObject cajonSecreto;
    private bool hecho = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (switch1.GetComponent<Interruptor>().cambio == 0
        && switch2.GetComponent<Interruptor>().cambio == 1
        && switch3.GetComponent<Interruptor>().cambio == 2
        && !hecho)
        {
            //luzSecreta.SetActive(true);
            cajonSecreto.GetComponent<Cajon>().enabled = true;
            cajonSecreto.GetComponent<Cajon>().AbreCierra();
            hecho = true;

        }

    }
}
