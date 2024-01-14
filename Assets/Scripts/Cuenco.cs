using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuenco : MonoBehaviour
{
    public GameObject player;
    public int contador = 0;
    public bool terminado = false;
    public GameObject procedimiento;
    public GameObject canvasResuelto;

    private void Start()
    {
        // Invocar la función DespuesDeUnSegundo después de un segundo cuando juegoTerminado sea true
    }

    // Update is called once per frame
    void Update()
    {
        if (contador == 5 && !terminado)
        {
            Debug.Log(terminado);
            procedimiento.SetActive(true);
            canvasResuelto.GetComponent<Animator>().SetBool("juegoTerminado", true);
            Invoke("DespuesDeUnSegundo", 1f);
        }
    }

    void DespuesDeUnSegundo()
    {
        // Ejecutar el código después de un segundo

        // Pausar el juego
        Time.timeScale = 0;

        // Hacer visible el cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Bloquear el movimiento del jugador
        player.GetComponent<PlayerController>().bloquear = true;

        terminado = true;
    }
}
