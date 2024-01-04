using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respiro : MonoBehaviour
{
    public float breathingStrength = 0.1f; // Ajusta la fuerza de la "respiración"

    void Update()
    {
        // Genera valores oscilantes usando Mathf.Sin y aplícalos a la posición de la cámara
        float breathing = Mathf.Sin(Time.time) * breathingStrength;
        transform.localPosition = new Vector3(breathing, 0.3301292f, 1.129231f); // Ajusta los ejes según tu preferencia
    }
}
