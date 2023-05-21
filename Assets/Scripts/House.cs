using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class House : MonoBehaviour
{
    public List<GameObject> floors = new List<GameObject>();
    public SelectController selectController;
    [SerializeField] GameObject floorHousePrefab;
    [SerializeField] GameObject floorFabricPrefab;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && floors.Count == 0)
        {
            Vector3 newHousePos = transform.position;
            newHousePos += new Vector3(0, 0.4f, -1);

            GameObject createdBlock = floorHousePrefab;
            TypeFloor typeFloor = TypeFloor.HouseFloor;

            if (selectController.selectedPrefab?.type == TypePrefab.House)
            {
                createdBlock = floorHousePrefab;
                typeFloor = TypeFloor.HouseFloor;
            }
            if (selectController.selectedPrefab?.type == TypePrefab.Fabric)
            {
                createdBlock = floorFabricPrefab;
                typeFloor = TypeFloor.FabricFloor;
            }

            GameObject floor = Instantiate(createdBlock, newHousePos, Quaternion.identity, gameObject.transform);
            floor.AddComponent<Floor>();
            floor.GetComponent<Floor>().selectController = selectController;
            floor.GetComponent<Floor>().parent = this;
            floor.GetComponent<Floor>().typeFloor = typeFloor;
            floors.Add(floor);

        } 
        

        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
        {
            Destroy(gameObject);
        }
    }
}
