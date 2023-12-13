using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrasenaCandado : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;

    [Header("Ruedas del candado")]
    public GameObject switch1;
    public GameObject switch2;
    public GameObject switch3;
    public GameObject switch4;

    [Header("Contraseña correcta")]
    private int[] password = new int[4];

    [Header("Variables de control")]
    private bool desbloqueado = false;
    public GameObject tapa;

    [Header("Variables para abrir el cofre")]
    public float anguloTapaAbierta = -200.0f; // Ángulo de la tapa al estar abierta
    public float anguloTapaCerrada = -90.0f; // Ángulo de la tapa al estar cerrada
    public float velocidad = 3.0f; // Velocidad con la que se abre la tapa

    [Header("Camaras")]
    public GameObject camaraJugador;
    public GameObject camaraCandado;

    // Start is called before the first frame update
    void Start()
    {
        password[0] = 1;
        password[1] = 3;
        password[2] = 6;
        password[3] = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (switch1.GetComponent<SwitchRueda>().numeroActual == password[0]
        && switch2.GetComponent<SwitchRueda>().numeroActual == password[1]
        && switch3.GetComponent<SwitchRueda>().numeroActual == password[2]
        && switch4.GetComponent<SwitchRueda>().numeroActual == password[3]
        && !desbloqueado)
        {
            Debug.Log("CANADO DESBLOQUEADO");

            // SALIR MODO CANDADO
            Quaternion targetRotation = Quaternion.Euler(anguloTapaAbierta, 0, 0);
            tapa.transform.localRotation = Quaternion.Slerp(tapa.transform.localRotation, targetRotation, velocidad * Time.deltaTime);

            // Cambio de cámara
            camaraCandado.SetActive(false);
            camaraJugador.SetActive(true);

            // hacemos invisible el cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // Desbloquear movimiento del jugador
            player.GetComponent<PlayerController>().bloquear = false;

        }
    }

    private IEnumerator esperar()
    {
        yield return new WaitForSecondsRealtime(3f);
    }
}