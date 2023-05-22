using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class House : MonoBehaviour
{
    public List<GameObject> floors = new List<GameObject>();
    public SelectController selectController;
    public ResourceController resourceController;

    [SerializeField] GameObject floorHousePrefab;
    [SerializeField] GameObject floorFabricPrefab;

    public bool isCanCreate;
    public bool isRoofBuild;

    private void Start()
    {
        isCanCreate = true;
    }

    public void HouseCompleted()
    {
        GlobalData.population += (floors.Count + 1) * 4;
        resourceController.coins -= (floors.Count + 1) * 50;
    }
    public void FabricCompleted()
    {
        resourceController.coins -= (floors.Count + 1) * 100;
        GlobalData.energy -= (floors.Count + 1) * 3;
        GlobalData.coins += (floors.Count + 1) * 2;
        GlobalData.polution += (floors.Count + 1) * 4;

    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && floors.Count == 0)
        {
            Vector3 newHousePos = transform.position;
            newHousePos += new Vector3(0, 0.4f, -1);

            GameObject createdBlock = floorHousePrefab;
            TypeFloor typeFloor = TypeFloor.HouseFloor;

            if (selectController.selectedPrefab?.type == TypePrefab.House && isCanCreate && !isRoofBuild)
            {
                createdBlock = floorHousePrefab;
                typeFloor = TypeFloor.HouseFloor;
            }

            if (selectController.selectedPrefab?.type == TypePrefab.Fabric && isCanCreate && !isRoofBuild)
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

            if (selectController.selectedPrefab?.type == TypePrefab.HouseRoof && isCanCreate && !isRoofBuild)
            {
                createdBlock = selectController.selectedPrefab.prefab;
                isCanCreate = false;
                isRoofBuild = true;
                Instantiate(createdBlock, newHousePos, Quaternion.identity, gameObject.transform);
                HouseCompleted();
            }
            if (selectController.selectedPrefab?.type == TypePrefab.FabricRoof && isCanCreate && !isRoofBuild)
            {
                createdBlock = selectController.selectedPrefab.prefab;
                isRoofBuild = true;
                Instantiate(createdBlock, newHousePos, Quaternion.identity, gameObject.transform);
            }
            if (selectController.selectedPrefab?.type == TypePrefab.FabricTube && isCanCreate && isRoofBuild)
            {
                createdBlock = selectController.selectedPrefab.prefab;
                isCanCreate = false;
                Instantiate(createdBlock, newHousePos, Quaternion.identity, gameObject.transform);
                FabricCompleted();
            }

        }


        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
        {
            Destroy(gameObject);
        }
    }
}
