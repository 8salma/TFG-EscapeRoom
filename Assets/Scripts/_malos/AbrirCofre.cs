using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirCofre : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void abrir()
    {
        anim.SetBool("abrir", true);
        Debug.Log("ABRE EL COFRE");
    }
}
