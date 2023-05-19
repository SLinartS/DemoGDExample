using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject[] stonePrefabs;
    [SerializeField] GameObject stonePos;
    [SerializeField] GameObject housePos;
    GameObject stone;
    GameObject house;

    public bool road;
    public int count;

    public GameController gameController;

    SpriteRenderer spriteRenderer;


    public Tile tileTop = null;
    public Tile tileBottom = null;
    public Tile tileRight = null;
    public Tile tileLeft = null;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        int numberTILT = Random.Range(1, 30);
        if (numberTILT < stonePrefabs.Length)
        {

            stone = Instantiate(stonePrefabs[numberTILT], stonePos.transform.position, Quaternion.identity, gameObject.transform);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
        {
            Destroy(stone);
        }
        if (!EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0) && !stone)
        {
            if (gameController.selectedSprite)
            {
                spriteRenderer.sprite = gameController.selectedSprite;
            }
            if (gameController.selectedPrefab)
            {
                house = Instantiate(gameController.selectedPrefab, housePos.transform.position, Quaternion.identity, gameObject.transform);
            }
            if (gameController.selectedRoadSprite)
            {
                spriteRenderer.sprite = gameController.selectedRoadSprite;
                road = true;
                TypeRoad();
                if (tileTop) tileTop.TypeRoad();
                if (tileBottom) tileBottom.TypeRoad();
                if (tileRight) tileRight.TypeRoad();
                if (tileLeft) tileLeft.TypeRoad();
            }

        }
    }

    public void TypeRoad()
    {
        count = 0;

        if (tileTop && tileTop.road)
        {
            count += 1;
        }
        if (tileRight && tileRight.road)
        {
            count += 2;
        }
        if (tileBottom && tileBottom.road)
        {
            count += 4;
        }
        if (tileLeft && tileLeft.road)
        {
            count += 8;
        }
        if (road)
        {
            spriteRenderer.sprite = Resources.Load<Sprite>(count.ToString());
        }
    }
}
