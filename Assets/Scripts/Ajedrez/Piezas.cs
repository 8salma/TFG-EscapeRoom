using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script que controla el movimeinto de las piezas de ajedrez
*/
public class Piezas : MonoBehaviour
{
    public Camera cam;
    Vector3 mousePosition;
    public bool enTablero = false;

    Vector3 GetMousePos()
    {
        return cam.WorldToScreenPoint(transform.position);
    }

    void OnMouseDown()
    {
        if (enTablero)
        {
            mousePosition = Input.mousePosition - GetMousePos();
        }
    }

    void OnMouseDrag()
    {
        if (enTablero)
        {
            Vector3 newPos = cam.ScreenToWorldPoint(Input.mousePosition - mousePosition);

            // convertir posicion del mouse a local
            newPos = transform.parent.InverseTransformPoint(newPos);

            // Limitaciones de movimiento
            newPos.x = Mathf.Clamp(Mathf.Round(newPos.x), 0f, 7f); // Limitar en el eje X
            newPos.y = 0f;
            newPos.z = Mathf.Clamp(Mathf.Round(newPos.z), 0f, 7f); // Limitar en el eje Z

            transform.localPosition = newPos;
        }
    }

}
