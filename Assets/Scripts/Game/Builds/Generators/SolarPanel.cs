using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SolarPanel : MonoBehaviour
{
    public void GeneratorComplete()
    {
        ResourceChangeData.energyChange += 1;
    }

    public void GeneratorDestroy()
    {
        ResourceChangeData.energyChange -= 1;
        Destroy(gameObject);
    }

    private void Start()
    {
        GeneratorComplete();
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
        {
            GeneratorDestroy();
        }
    }
}
