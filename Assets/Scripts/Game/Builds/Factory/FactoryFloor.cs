using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FactoryFloor : MonoBehaviour
{
    public Factory parent;
    public BuildController buildController;

    private void OnMouseDown()
    {
        Vector3 pos = transform.position;
        pos += new Vector3(0, 0.4f, -1);

        if (!parent.isComplete && !EventSystem.current.IsPointerOverGameObject())
        {
            if (buildController.selectedBuild.type == BuildType.FactoryFloor && parent.floors.Count < parent.maxFloor)
            {
                if (ResourceChangeData.AddCoinsAction(-100))
                {
                    GameObject floor = Instantiate(buildController.selectedBuild.prefab, pos, Quaternion.identity, transform);
                    floor.GetComponent<FactoryFloor>().parent = parent;
                    floor.GetComponent<FactoryFloor>().buildController = buildController;
                    parent.floors.Add(floor);
                };

            }
            if (buildController.selectedBuild.type == BuildType.FactoryRoof)
            {
                if (ResourceChangeData.AddCoinsAction(-50))
                {
                    pos += new Vector3(0, -0.1f, 0);
                    parent.roof = Instantiate(buildController.selectedBuild.prefab, pos, Quaternion.identity, transform);
                    parent.roof.GetComponent<FactoryRoof>().parent = parent;
                    parent.roof.GetComponent<FactoryRoof>().buildController = buildController;
                };

            }
        }
    }
}
