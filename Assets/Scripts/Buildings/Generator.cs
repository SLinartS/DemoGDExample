using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private int energy;
    public TypePrefab typePrefab;
    public ResourceController resourceController;

    private void Start()
    {
        if (typePrefab == TypePrefab.GeneratorWind)
        {
            energy = 2;
            resourceController.coins -= 30;
        }
        if (typePrefab == TypePrefab.GeneratorSun)
        {
            energy = 1;
            resourceController.coins -= 15;
        }

        GlobalData.energy += energy;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
        {
            Destroy(gameObject);
        }
    }
}
