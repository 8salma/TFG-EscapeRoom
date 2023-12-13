using UnityEngine;

public class Manillas : MonoBehaviour
{
    private bool arrastrando = false;
    private Vector3 posicionRatonAnterior;
    public GameObject pivote;
    private float anguloActual;

    void OnMouseDown()
    {
        arrastrando = true;
        posicionRatonAnterior = Input.mousePosition;
        anguloActual = pivote.transform.localEulerAngles.y;
    }

    void OnMouseUp()
    {
        arrastrando = false;
    }

    void OnMouseDrag()
    {
        if (arrastrando)
        {
            Vector3 diferencia = Input.mousePosition - posicionRatonAnterior;
            float rotacionY = -diferencia.x * 0.5f; // Ajusta la velocidad de rotación según sea necesario

            // Sumar la rotación actual con la rotación del movimiento del ratón
            float nuevaRotacion = anguloActual + rotacionY;

            // Limitar la rotación entre 0 y 360 grados
            //nuevaRotacion = Mathf.Clamp(nuevaRotacion, 0f, 360f);

            // Aplicar la nueva rotación solo en el eje Y
            pivote.transform.localEulerAngles = new Vector3(0, nuevaRotacion, 0);

            posicionRatonAnterior = Input.mousePosition;
            anguloActual = nuevaRotacion;
        }
    }
}