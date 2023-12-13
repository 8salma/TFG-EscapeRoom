using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverIman : MonoBehaviour
{

    private GameObject selectedObject;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null && hit.collider.CompareTag("drag"))
                {
                    selectedObject = hit.collider.gameObject;
                    Cursor.visible = false;
                }
            }
            else
            {
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = cam.ScreenToWorldPoint(position);
                selectedObject.transform.position = new Vector3(worldPosition.x, 0f, worldPosition.z);

                selectedObject = null;
                Cursor.visible = true;
            }
        }

        if (selectedObject != null)
        {
            Debug.Log("hola!!!!");
            Debug.Log("objeto: " + selectedObject);

            Vector2 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = cam.ScreenToWorldPoint(position);

            Debug.Log("posMouse = " + position);
            Debug.Log("pos = " + worldPosition);
            // selectedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0.2179688f);
            selectedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y,  0.2179688f);

            /*
            if (Input.GetMouseButtonDown(1))
            {
                selectedObject.transform.rotation = Quaternion.Euler(new Vector3(
                    selectedObject.transform.rotation.eulerAngles.x,
                    selectedObject.transform.rotation.eulerAngles.y + 90f,
                    selectedObject.transform.rotation.eulerAngles.z));
            }
            */
        }

    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane);
        Vector3 worldMousePosFar = cam.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = cam.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        Debug.DrawRay(worldMousePosNear, worldMousePosFar - worldMousePosNear, Color.red);

        return hit;
    }
}
