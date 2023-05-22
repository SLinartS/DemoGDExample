using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private int ecology = 4;
    public ResourceController resourceController;

    private void Start()
    {
        GlobalData.polution -= ecology;
        resourceController.coins -= 10;
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
        {
            Destroy(gameObject);
        }
    }
}
