using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public House parent;
    public SelectController selectController;

    public bool isCanCreate;
    public bool isRoofBuild;

    public TypeFloor typeFloor;

    private void Start()
    {
        isCanCreate = true;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && parent.floors.Count <= 7 && isCanCreate)
        {
            if (selectController.selectedPrefab?.type == TypePrefab.House || selectController.selectedPrefab?.type == TypePrefab.Fabric)
            {
                Vector3 newHousePos = transform.position;
                newHousePos += new Vector3(0, 0.4f, 0);

                GameObject floor = Instantiate(gameObject, newHousePos, Quaternion.identity, gameObject.transform);
                parent.floors.Add(floor);
                isCanCreate = false;
            }
        }

        if (Input.GetMouseButtonDown(0) && isCanCreate)
        {
            if ((typeFloor == TypeFloor.HouseFloor && selectController.selectedPrefab?.type == TypePrefab.HouseRoof)
                || (typeFloor == TypeFloor.FabricFloor && selectController.selectedPrefab?.type == TypePrefab.FabricRoof))
            {
                Vector3 newHousePos = transform.position;
                newHousePos += new Vector3(0, 0.3f, -1);

                GameObject roof = Instantiate(selectController.selectedPrefab.prefab, newHousePos, Quaternion.identity, gameObject.transform);
                isRoofBuild = true;
                if (typeFloor == TypeFloor.HouseFloor)
                {
                    isCanCreate = false;
                }
            }
            if (isRoofBuild && typeFloor == TypeFloor.FabricFloor && selectController.selectedPrefab?.type == TypePrefab.FabricTube)
            {
                Vector3 newHousePos = transform.position;
                newHousePos += new Vector3(0, 0.3f, -1);

                GameObject roof = Instantiate(selectController.selectedPrefab.prefab, newHousePos, Quaternion.identity, gameObject.transform);
                isCanCreate = false;
            }
        }

        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
        {
            Destroy(gameObject);
        }
    }
}
