using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject buildWindow;

    private Vector3 startPos;
    private Vector3 endPos;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (!buildWindow.activeSelf)
        {
            if (Input.GetMouseButtonDown(2))
            {
                startPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.GetMouseButton(2))
            {
                endPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                mainCamera.transform.position += startPos - endPos;
            }

            Vector3 whileDelta = Input.mouseScrollDelta;

            if (whileDelta.y > 0 && mainCamera.orthographicSize > 3 || whileDelta.y < 0 && mainCamera.orthographicSize < 10)
            {
                mainCamera.orthographicSize -= whileDelta.y;
            }
        }

    }
}
