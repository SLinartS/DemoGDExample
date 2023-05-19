using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;
    [SerializeField] GameObject tileMap;

    [SerializeField] float offsetX;
    [SerializeField] float offsetY;
    [SerializeField] int width;
    [SerializeField] int height;

    public Sprite selectedSprite;
    public Sprite selectedRoadSprite;
    public GameObject selectedPrefab;
    public Tile[,] tiles;


    private void Awake()
    {
        tiles = new Tile[width, height];
    }

    void Start()
    {
        CreateMap();
    }


    void Update()
    {

    }

    void CreateMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 pos;
                if (y % 2 == 0)
                {
                    pos = new Vector3(offsetX * x - width / 2, offsetY * y - height / 4, y);
                }
                else
                {
                    pos = new Vector3(offsetX * x + offsetX / 2 - width / 2, offsetY * y - height / 4, y);
                }
                GameObject newtile = Instantiate(tilePrefab, pos, Quaternion.identity, tileMap.transform);
                newtile.GetComponent<Tile>().gameController = this;

                tiles[x, y] = newtile.GetComponent<Tile>();
            }
        }
        InitialTile();
    }

    public void SelectTile(Sprite newSprite)
    {
        selectedPrefab = null;
        selectedRoadSprite = null;
        selectedSprite = newSprite;
    }

    public void SelectHouse(GameObject newPrefab)
    {
        selectedSprite = null;
        selectedRoadSprite = null;
        selectedPrefab = newPrefab;
    }    
    public void SelectRoadSprite(Sprite newRoadSprite)
    {
        selectedSprite = null;
        selectedPrefab = null;
        selectedRoadSprite = newRoadSprite;
    }

    public void InitialTile()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (y % 2 == 0)
                {
                    if (y + 1 < height)
                    {
                        tiles[x, y].tileTop = tiles[x, y + 1];
                    }

                    if (x - 1 >= 0 && y - 1 >= 0)
                    {
                        tiles[x, y].tileBottom = tiles[x - 1, y - 1];
                    }

                    if (y - 1 >= 0)
                    {
                        tiles[x, y].tileRight = tiles[x, y - 1];
                    }

                    if (x - 1 >= 0 && y + 1 < height)
                    {
                        tiles[x, y].tileLeft = tiles[x - 1, y + 1];
                    }

                }
                else
                {
                    if (x + 1 < width && y + 1 < height)
                    {
                        tiles[x, y].tileTop = tiles[x + 1, y + 1];
                    }

                    if (y - 1 != -1)
                    {
                        tiles[x, y].tileBottom = tiles[x, y - 1];
                    }

                    if (x + 1 < width & y - 1 != -1)
                    {
                        tiles[x, y].tileRight = tiles[x + 1, y - 1];
                    }

                    if (y + 1 < height)
                    {
                        tiles[x, y].tileLeft = tiles[x, y + 1];
                    }
                }
            }
        }
    }
}
