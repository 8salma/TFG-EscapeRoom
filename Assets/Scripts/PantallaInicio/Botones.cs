using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botones : MonoBehaviour
{
    public GameObject player;
    public GameObject pausa;

    public void playButton()
    {
        // SceneManager.LoadScene(1);
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
