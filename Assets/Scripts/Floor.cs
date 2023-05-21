using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public House parent;
    public GameController gameController;

    public bool isCanCreate;

    private void Start()
    {
        isCanCreate = true;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && gameController.selectedPrefab && parent.floors.Count <= 7 && isCanCreate)
        {
            Vector3 newHousePos = transform.position;
            newHousePos += new Vector3(0, 0.4f, 0);

            GameObject floor = Instantiate(gameObject, newHousePos, Quaternion.identity, gameObject.transform);
            parent.floors.Add(floor);
            isCanCreate = false;
        }

        if (Input.GetMouseButtonDown(0) && gameController.selectedRoofPrefab && isCanCreate)
        {
            Vector3 newHousePos = transform.position;
            newHousePos += new Vector3(0, 0.3f, 0);

            GameObject roof = Instantiate(gameController.selectedRoofPrefab, newHousePos, Quaternion.identity, gameObject.transform);
            isCanCreate = false;
        }

        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
        {
            Destroy(gameObject);
        }
    }
}
