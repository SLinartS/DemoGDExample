using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tree : MonoBehaviour
{
    public void TreeComplete()
    {
        ResourceChangeData.polutionChange -= 2;
    }

    public void TreeDestroy()
    {
        ResourceChangeData.polutionChange += 2;
        Destroy(gameObject);
    }

    private void Start()
    {
        TreeComplete();
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
        {
            TreeDestroy();
        }
    }
}
