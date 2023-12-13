using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimmer : MonoBehaviour
{
    private float rotationSpeed = 90.0f; // Velocidad constante de rotación en grados por segundo
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private bool isRotating = false;
    private float rotationTime = 0f;
    private float maxRotationTime = 1f; // Tiempo máximo de rotación

    private float currentTotalAngle = -45f; // Ángulo total acumulado
    public int numeroActual;

    void Start()
    {
        initialRotation = transform.localRotation;
        numeroActual = 1;
    }

    void Update()
    {
        if (isRotating)
        {
            // Calcular la velocidad de rotación en función del tiempo deseado para rotar un ángulo específico
            float angleToRotate = rotationSpeed * Time.deltaTime;

            rotationTime += Time.deltaTime;
            float t = Mathf.Clamp01(rotationTime / maxRotationTime);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, t);

            if (rotationTime >= maxRotationTime)
            {
                isRotating = false;
                rotationTime = 0f;
                initialRotation = transform.localRotation; // Actualizar la rotación inicial
            }
        }
    }

    public void ChangeDimmerState()
    {
        // cambio de numero
        numeroActual++;
        if (numeroActual == 5) numeroActual = 1;

        // Sumar la cantidad de ángulo a rotar al ángulo total acumulado
        currentTotalAngle += 90f;

        // Asegurarse de que el ángulo esté en el rango [0, 360]
        //currentTotalAngle = Mathf.Repeat(currentTotalAngle, 360.0f);

        // Definir el objetivo de rotación con el nuevo ángulo acumulado en el eje X
        targetRotation = Quaternion.Euler(-180f, -1.525879e-05f, currentTotalAngle);

        // Calcular el tiempo necesario para alcanzar el ángulo deseado a la velocidad constante
        float angleToRotate = Mathf.Abs(90f);
        maxRotationTime = angleToRotate / rotationSpeed;

        // Comenzar la rotación
        isRotating = true;
    }
}