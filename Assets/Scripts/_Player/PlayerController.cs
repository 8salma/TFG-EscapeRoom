using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*   Scrip encargado de:
*   -   Moviemiento del jugador con wasd y salto
*   -   Moviemeinto de la cámara con el ratón
*   -   Variables de control para bloquear moviemientos del jugador
*   -   Puntero en medio de la pantalla
*/

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    [Header("Movimiento del Personaje")]
    public float walkSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravedad = 20.0f;

    [Header("Movimiento de la Cámara")]
    public Camera cam;
    public float mouseHorizontal = 3.0f;
    public float mouseVertical = 2.0f;
    public float minRotation = -65.0f;
    public float maxRotation = 60.0f;
    float h_mouse, v_mouse;

    [Header("Variables de control de lo que tengo")]
    public bool bloquear = false;
    public bool tengoMando = false;
    public bool tengoLlave = false;
    public bool tengoPieza = false;
    public bool tengoMartillo = false;
    public bool tengoIngrediente = false;
    public string tagLlave;

    [Header("Menú de pausa")]
    public GameObject pausa;

    [Header("Variables para controlar si el juego ha acabado")]
    public GameObject cuenco;
    bool juegoTerminado;

    private Vector3 move = Vector3.zero;

    void Start()
    {
        // cursor invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        juegoTerminado = cuenco.GetComponent<Cuenco>().terminado;

        // pausar con la tecla escape
        if (Input.GetKeyDown(KeyCode.Escape) && !juegoTerminado)
        {
            pausa.SetActive(true);
            Time.timeScale = 0;

            // hacemos visible el cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            bloquear = true;
        }

        if (!bloquear)
        {
            RotacionCamara();
            UpdateMovimiento();
        }
    }

    private void UpdateMovimiento()
    {
        if (characterController.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            move = transform.TransformDirection(move) * walkSpeed;

            // Salto
            if (Input.GetKey(KeyCode.Space))
            {
                move.y = jumpSpeed;
            }
        }

        move.y -= gravedad * Time.deltaTime;
        characterController.Move(move * Time.deltaTime);
    }

    private void RotacionCamara()
    {
        // Obtener la rotación horizontal del mouse
        float h_mouse = Input.GetAxis("Mouse X");

        // Limitar la rotación vertical de la cámara
        v_mouse += mouseVertical * Input.GetAxis("Mouse Y");
        v_mouse = Mathf.Clamp(v_mouse, minRotation, maxRotation);
        cam.transform.localEulerAngles = new Vector3(v_mouse, 0, 0);

        // Aplicar rotación horizontal al jugador (no a la cámara)
        transform.Rotate(Vector3.up * h_mouse);
    }
}
