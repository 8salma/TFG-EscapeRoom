using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jarron : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        // Obtener el componente Animator del objeto al que está adjunto este script
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void romper()
    {
        anim.SetBool("romper", true);
        Debug.Log(anim.GetBool("romper"));
    }
}
