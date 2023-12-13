using UnityEngine;

public class InspeccionObjeto : MonoBehaviour
{
    private bool rotando = false;
    private float velocidadRotacion = 5.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rotando = true; // Activa la rotación al hacer clic en cualquier parte de la pantalla
        }

        if (Input.GetMouseButtonUp(0))
        {
            rotando = false; // Detiene la rotación al soltar el clic del mouse
        }

        if (rotando)
        {
            float rotX = Input.GetAxis("Mouse X") * velocidadRotacion;
            float rotY = Input.GetAxis("Mouse Y") * velocidadRotacion;

            transform.RotateAround(transform.position, Vector3.up, -rotX);
            transform.RotateAround(transform.position, transform.right, -rotY);
        }
    }
}