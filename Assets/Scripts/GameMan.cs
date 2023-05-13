using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameMan : MonoBehaviour
{
    [SerializeField] float offsetX;
    [SerializeField] float offsetY;
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] GameObject prefab;

    public Tile[,] tiles;

    private void Awake()
    {
        tiles = new Tile[width, height];
    }

    public void Start()
    {
        CreateMap();
    }

    public void CreateMap()
    {
        Vector3 pos = new Vector3();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (y % 2 == 0)
                {
                    pos = new Vector3(x * offsetX, y * offsetY, y);
                }
                else
                {
                    pos = new Vector3(x * offsetX + (offsetX / 2), y * offsetY, y);
                }

                GameObject clone = Instantiate(prefab, pos, Quaternion.identity, gameObject.transform);
                clone.GetComponent<Tile>().game = this;
                tiles[x, y] = clone.GetComponent<Tile>();
            }
        }
        InitialTile();
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
                        tiles[x, y].TileTop = tiles[x, y + 1];
                    }

                    if (x - 1 != -1 && y - 1 != -1)
                    {
                        tiles[x, y].TileBottom = tiles[x - 1, y - 1];
                    }

                    if (y - 1 != -1)
                    {
                        tiles[x, y].TileRight = tiles[x, y - 1];
                    }

                    if (x - 1 != -1 && y + 1 < height)
                    {
                        tiles[x, y].TileLeft = tiles[x - 1, y + 1];
                    }

                }
                else
                {
                    if (x + 1 < width && y + 1 < height)
                    {
                        tiles[x, y].TileTop = tiles[x + 1, y + 1];
                    }

                    if (y - 1 != -1)
                    {
                        tiles[x, y].TileBottom = tiles[x, y - 1];
                    }

                    if (x + 1 < width & y - 1 != -1)
                    {
                        tiles[x, y].TileRight = tiles[x + 1, y - 1];
                    }

                    if (y + 1 < height)
                    {
                        tiles[x, y].TileLeft = tiles[x, y + 1];
                    }

                }
            }
        }
    }

    public Sprite paletType;

    public void CreateRoad(Sprite PaletType)
    {
        paletType = PaletType;
    }
}
