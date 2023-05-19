using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    [SerializeField] Camera mainCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            startPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(2))
        {
            endPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        gameObject.transform.position += startPos - endPos;

        Vector3 zoom = Input.mouseScrollDelta;

        if (zoom != Vector3.zero)
        {
            if (mainCamera.orthographicSize - zoom.y >= 1 && mainCamera.orthographicSize - zoom.y < 10)
            {
                mainCamera.orthographicSize -= zoom.y;
            }

        }
    }
}
