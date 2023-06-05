using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HouseFloor : MonoBehaviour
{
    public House parent;
    public BuildController buildController;

    private void OnMouseDown()
    {
        Vector3 pos = transform.position;
        pos += new Vector3(0, 0.4f, -1);

        if (!parent.isComplete && !EventSystem.current.IsPointerOverGameObject())
        {
            if (buildController.selectedBuild.type == BuildType.HouseFoor && parent.floors.Count < parent.maxFloor)
            {
                if (ResourceChangeData.AddCoinsAction(-50))
                {
                    GameObject floor = Instantiate(buildController.selectedBuild.prefab, pos, Quaternion.identity, transform);
                    floor.GetComponent<HouseFloor>().parent = parent;
                    floor.GetComponent<HouseFloor>().buildController = buildController;
                    parent.floors.Add(floor);
                };

            }
            if (buildController.selectedBuild.type == BuildType.HouseRoof)
            {
                if (ResourceChangeData.AddCoinsAction(-25))
                {
                    pos += new Vector3(0, -0.1f, 0);
                    Instantiate(buildController.selectedBuild.prefab, pos, Quaternion.identity, transform);
                    parent.HouseComplete();
                };

            }
        }
    }
}
