using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;

    [SerializeField]
    private BuildController buildController;

    [SerializeField]
    private int width;
    [SerializeField]
    private int heigth;
    [SerializeField]
    private float offsetX;
    [SerializeField]
    private float offsetY;

    private Tile[,] tiles;

    private void Awake()
    {
        tiles = new Tile[width, heigth];
    }

    void Start()
    {
        GenerateMap();
        InitialTiles();
    }

    private void GenerateMap()
    {
        Vector3 pos;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < heigth; y++)
            {
                if (y % 2 == 0)
                {
                    pos = new Vector3(x * offsetX, y * offsetY, y);
                }
                else
                {
                    pos = new Vector3(x * offsetX + offsetX / 2, y * offsetY, y);
                }

                pos -= new Vector3(width / 2, heigth / 4, 0);

                GameObject newTile = Instantiate(tilePrefab, pos, Quaternion.identity, gameObject.transform);
                newTile.GetComponent<Tile>().buildController = buildController;

                tiles[x, y] = newTile.GetComponent<Tile>();
            }
        }
    }

    private void InitialTiles()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < heigth; y++)
            {
                if (y % 2 == 0)
                {
                    if (y + 1 < heigth)
                    {
                        tiles[x, y].tileTop = tiles[x, y + 1];
                    }
                    if (x - 1 >= 0 && y - 1 >= 0)
                    {
                        tiles[x, y].tileBottom = tiles[x - 1, y - 1];
                    }
                    if (x - 1 >= 0 && y + 1 < heigth)
                    {
                        tiles[x, y].tileLeft = tiles[x - 1, y + 1];
                    }
                    if (y - 1 >= 0)
                    {
                        tiles[x, y].tileRight = tiles[x, y - 1];
                    }
                }
                else
                {
                    if (x + 1 < width && y + 1 < heigth)
                    {
                        tiles[x, y].tileTop = tiles[x + 1, y + 1];
                    }
                    if (y - 1 >= 0)
                    {
                        tiles[x, y].tileBottom = tiles[x, y - 1];
                    }
                    if (y + 1 < heigth)
                    {
                        tiles[x, y].tileLeft = tiles[x, y + 1];

                    }
                    if (x + 1 < width && y - 1 >= 0)
                    {
                        tiles[x, y].tileRight = tiles[x + 1, y - 1];
                    }
                }
            }
        }
    }
}
