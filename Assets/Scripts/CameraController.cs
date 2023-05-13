using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector2 startPos;
    Vector2 endPos;
    [SerializeField] Camera main;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(1)) 
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 resultPos = startPos - endPos;
            gameObject.transform.position += (Vector3)resultPos;
        }

        Vector2 zoom = Input.mouseScrollDelta;

        if (zoom != Vector2.zero)
        {
            main.orthographicSize -= zoom.y;
        }
    }
}
