using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Factory : MonoBehaviour
{
    public List<GameObject> floors;
    public GameObject roof;
    public GameObject tube;

    public BuildController buildController;
    public bool isComplete;

    public int maxFloor = 5;

    public void FactoryComplete()
    {
        ResourceChangeData.energyChange -= (floors.Count + 1) * 2;
        ResourceChangeData.coinsChange += (floors.Count + 1) * 2;
        ResourceChangeData.polutionChange += (floors.Count + 1) * 4;
        isComplete = true;
    }

    public void FactoryDestroy()
    {
        ResourceChangeData.energyChange += (floors.Count + 1) * 2;
        ResourceChangeData.coinsChange -= (floors.Count + 1) * 2;
        ResourceChangeData.polutionChange -= (floors.Count + 1) * 4;
        Destroy(tube);
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
                if (buildController.selectedBuild.type == BuildType.FactoryFloor && floors.Count < maxFloor)
                {
                    if (ResourceChangeData.AddCoinsAction(-100))
                    {
                        GameObject floor = Instantiate(buildController.selectedBuild.prefab, pos, Quaternion.identity, transform);
                        floor.GetComponent<FactoryFloor>().parent = this;
                        floor.GetComponent<FactoryFloor>().buildController = buildController;
                        floors.Add(floor);
                    };

                }
                if (buildController.selectedBuild.type == BuildType.FactoryRoof)
                {
                    if (ResourceChangeData.AddCoinsAction(-50))
                    {
                        pos += new Vector3(0, -0.1f, 0);
                        roof = Instantiate(buildController.selectedBuild.prefab, pos, Quaternion.identity, transform);
                        roof.GetComponent<FactoryRoof>().parent = this;
                        roof.GetComponent<FactoryRoof>().buildController = buildController;
                    };

                }
            }

            if (isComplete && Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
            {
                FactoryDestroy();
            }
        }

    }
}
