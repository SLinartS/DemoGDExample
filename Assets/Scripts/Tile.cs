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

    public GameController gameController;

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
            if (gameController.selectedSprite)
            {
                spriteRenderer.sprite = gameController.selectedSprite;
                road = false;
            }
            if (gameController.selectedPrefab)  
            {
                //Vector3 newHousePos = housePos.transform.position;
                //newHousePos += new Vector3(0, 0.4f * houses.Count, 0);

                child = Instantiate(gameController.selectedPrefab, housePos.transform.position, Quaternion.identity, gameObject.transform);
                child.GetComponent<House>().gameController = gameController;
                spriteRenderer.sprite = initSprite;
                road = false;
            }
            if (gameController.selectedRoadSprite && !child)
            {
                spriteRenderer.sprite = gameController.selectedRoadSprite;
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
