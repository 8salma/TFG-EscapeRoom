using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Television : MonoBehaviour
{
    public GameObject[] videos = new GameObject[4];
    private int sigCanal = 0;
    private bool apagar = false;

    public void CambioCanal()
    {
        if (apagar)
        {
            videos[sigCanal - 1].SetActive(false);
            apagar = false;
            sigCanal = 0;
        }
        else
        {
            Debug.Log("enciendo tv");
            if (sigCanal != 0)
            {
                videos[sigCanal - 1].SetActive(false);
            }
            videos[sigCanal].SetActive(true);
            sigCanal++;
            if (sigCanal == 3)
            {
                apagar = true;
            }
        }
    }
}
