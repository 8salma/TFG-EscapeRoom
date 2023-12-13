using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBueno : MonoBehaviour
{
    public Camera cam;
    Vector3 mousePosition;

    Vector3 GetMousePos()
    {
        return cam.WorldToScreenPoint(transform.position);
    }

    void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }

    void OnMouseDrag()
    {
        Vector3 newPos = cam.ScreenToWorldPoint(Input.mousePosition - mousePosition);

        // convertir posicion del mouse a local
        newPos = transform.parent.InverseTransformPoint(newPos);

        // Limitaciones de movimiento
        newPos.x = Mathf.Clamp(newPos.x, 0.00068f, 0.00458f); // Limitar en el eje X
        newPos.y = -0.00168f;
        newPos.z = Mathf.Clamp(newPos.z, 0.0012f, 0.00355f); // Limitar en el eje Y

        transform.localPosition = newPos;
    }
}
