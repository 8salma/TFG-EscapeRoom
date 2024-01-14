using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    public GameObject player;
    public GameObject pausa;
    public GameObject inicio;
    public GameObject seleccion;

    public void playButton()
    {
        // inicio.SetActive(false);
        // seleccion.SetActive(true);
    }

    public void gofresButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void exitButton()
    {
        Debug.Log("saliendo...");
        Application.Quit();
    }

    public void resumeButton()
    {
        pausa.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        player.GetComponent<PlayerController>().bloquear = false;
    }


}
