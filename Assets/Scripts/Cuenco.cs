using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuenco : MonoBehaviour
{
    public int contador = 0;
    private bool terminado = false;
    public GameObject procedimiento;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (contador == 5 && !terminado)
        {
            Debug.Log(terminado);
            procedimiento.SetActive(true);
            terminado = true;
        }

    }
}
