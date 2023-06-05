using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class House : MonoBehaviour
{
    public List<GameObject> floors;
    public GameObject roof;

    public BuildController buildController;
    public bool isComplete;

    public int maxFloor = 5;

    public void HouseComplete()
    {
        ResourceChangeData.AddPopulationAction((floors.Count + 1) * 10);
        isComplete = true;
    }

    public void HouseDestroy()
    {
        ResourceChangeData.AddPopulationAction((floors.Count + 1) * -10);
        Destroy(roof);
        foreach (GameObject floor in floors)
        {
            Destroy(floor);
        }
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Vector3 pos = transform.position;
        pos += new Vector3(0, 0.4f, -1);

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (!isComplete)
            {
                if (buildController.selectedBuild.type == BuildType.HouseFoor && floors.Count < maxFloor)
                {
                    if (ResourceChangeData.AddCoinsAction(-50))
                    {
                        GameObject floor = Instantiate(buildController.selectedBuild.prefab, pos, Quaternion.identity, transform);
                        floor.GetComponent<HouseFloor>().parent = this;
                        floor.GetComponent<HouseFloor>().buildController = buildController;
                        floors.Add(floor);
                    };

                }
                if (buildController.selectedBuild.type == BuildType.HouseRoof)
                {
                    if (ResourceChangeData.AddCoinsAction(-25))
                    {
                        pos += new Vector3(0, -0.1f, 0);
                        Instantiate(buildController.selectedBuild.prefab, pos, Quaternion.identity, transform);
                        HouseComplete();
                    };

                }
            }

            if (isComplete && Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
            {
                HouseDestroy();
            }
        }

    }
}
