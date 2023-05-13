using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject build;
    public List<GameObject> prefabStone;
    public GameObject child;
    SpriteRenderer spriteRenderer;

    public Tile TileTop = null;
    public Tile TileBottom = null;
    public Tile TileRight = null;
    public Tile TileLeft = null;

    public bool road;
    public int count;

    public GameMan game;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        int n = Random.Range(0, prefabStone.Count * 3);
        if (n < prefabStone.Count)
        {
            child = Instantiate(prefabStone[n], build.transform.position, Quaternion.identity);
        }
    }
    private void OnMouseDown()
    {
        spriteRenderer.sprite = game.paletType;
        road = true;
        myType();
        if (TileTop) TileTop.myType();
        if (TileRight) TileRight.myType();
        if (TileBottom) TileBottom.myType();
        if (TileLeft) TileLeft.myType();
        //if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
        //{
        //    if (child != null)
        //    {
        //        Destroy(child);
        //    }
        //}
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (child == null)
        //    {
        //        spriteRenderer.sprite = game.paletType;
        //    }
        //}
    }

    public void myType()
    {
        count = 0;

        if (TileTop && TileTop.road)
        {
            count += 1;
        }
        if (TileRight && TileRight.road)
        {
            count += 2;
        }
        if (TileBottom && TileBottom.road)
        {
            count += 4;
        }
        if (TileLeft && TileLeft.road)
        {
            count += 8;
        }
        if (road)
        {
            spriteRenderer.sprite = Resources.Load<Sprite>(count.ToString());
        }
    }
}
