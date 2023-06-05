using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FactoryRoof : MonoBehaviour
{
    public Factory parent;
    public BuildController buildController;

    private void OnMouseDown()
    {
        Vector3 pos = transform.position;
        pos += new Vector3(0, 0.4f, -1);

        if (!parent.isComplete && !EventSystem.current.IsPointerOverGameObject())
        {
            if (buildController.selectedBuild.type == BuildType.FactoryTube && parent.roof)
            {
                if (ResourceChangeData.AddCoinsAction(-50))
                {
                    pos += new Vector3(-0.4f, 0, +3);
                    parent.tube = Instantiate(buildController.selectedBuild.prefab, pos, Quaternion.identity, transform);
                    parent.FactoryComplete();
                };

            }
        }
    }
}
