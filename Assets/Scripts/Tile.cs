using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject[] stonePrefabs;
    [SerializeField] GameObject stonePos;
    [SerializeField] GameObject housePos;
    GameObject child;

    public bool road;
    public int count;

    public SelectController selectController;
    public ResourceController resourceController;

    SpriteRenderer spriteRenderer;
    Sprite initSprite;


    public Tile tileTop = null;
    public Tile tileBottom = null;
    public Tile tileRight = null;
    public Tile tileLeft = null;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initSprite = spriteRenderer.sprite;
    }

    private void Start()
    {
        SpawnStone();
    }

    public void SpawnStone()
    {
        int numberTILT = Random.Range(1, 30);
        if (numberTILT < stonePrefabs.Length)
        {
            child = Instantiate(stonePrefabs[numberTILT], stonePos.transform.position, Quaternion.identity, gameObject.transform);
            child.AddComponent<Stone>();
        }
    }

    private void OnMouseDown()
    {

        if (!Input.GetKey(KeyCode.LeftControl) && !EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButton(0) && !child)
        {
            if (selectController.selectedSprite)
            {
                spriteRenderer.sprite = selectController.selectedSprite;
                road = false;
            }
            if (selectController.selectedPrefab != null)
            {
                if (selectController.selectedPrefab.type == TypePrefab.House || selectController.selectedPrefab.type == TypePrefab.Fabric)
                {
                    child = Instantiate(selectController.selectedPrefab.prefab, housePos.transform.position, Quaternion.identity, gameObject.transform);
                    child.GetComponent<House>().selectController = selectController;
                    child.GetComponent<House>().resourceController = resourceController;
                }
                if (selectController.selectedPrefab.type == TypePrefab.Tree)
                {
                    child = Instantiate(selectController.selectedPrefab.prefab, housePos.transform.position, Quaternion.identity, gameObject.transform);
                    child.GetComponent<Tree>().resourceController = resourceController;
                }
                if (selectController.selectedPrefab.type == TypePrefab.GeneratorWind || selectController.selectedPrefab.type == TypePrefab.GeneratorSun)
                {
                    child = Instantiate(selectController.selectedPrefab.prefab, housePos.transform.position, Quaternion.identity, gameObject.transform);
                    child.GetComponent<Generator>().typePrefab = selectController.selectedPrefab.type;
                    child.GetComponent<Generator>().resourceController = resourceController;
                }

                spriteRenderer.sprite = initSprite;
                road = false;
            }
            if (selectController.selectedRoadSprite && !child)
            {
                spriteRenderer.sprite = selectController.selectedRoadSprite;
                road = true;
            }
            TypeRoad();
            if (tileTop) tileTop.TypeRoad();
            if (tileBottom) tileBottom.TypeRoad();
            if (tileRight) tileRight.TypeRoad();
            if (tileLeft) tileLeft.TypeRoad();
        }
    }

    public void TypeRoad()
    {
        count = 0;

        if (tileTop && tileTop.road)
        {
            count += 4;
        }
        if (tileRight && tileRight.road)
        {
            count += 8;
        }
        if (tileBottom && tileBottom.road)
        {
            count += 1;
        }
        if (tileLeft && tileLeft.road)
        {
            count += 2;
        }
        if (road)
        {
            spriteRenderer.sprite = Resources.Load<Sprite>(count.ToString());
        }
    }
}
