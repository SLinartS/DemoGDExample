using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class House : MonoBehaviour
{
    public List<GameObject> floors = new List<GameObject>();
    public GameController gameController;
    [SerializeField] GameObject floorPrefab;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && gameController.selectedPrefab && floors.Count == 0)
        {
            Vector3 newHousePos = transform.position;
            newHousePos += new Vector3(0, 0.4f, -1);

            GameObject floor= Instantiate(floorPrefab, newHousePos, Quaternion.identity, gameObject.transform);
            floor.AddComponent<Floor>();
            floor.GetComponent<Floor>().gameController = gameController;
            floor.GetComponent<Floor>().parent = this;
            floors.Add(floor);

        }

        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
        {
            Destroy(gameObject);
        }
    }
}
