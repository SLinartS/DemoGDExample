using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private Transform stonePos;
    [SerializeField]
    private GameObject[] stonePrefabs;

    [SerializeField]
    private Transform buildPose;
    [SerializeField]
    private Transform windMillPose;

    [SerializeField]
    private Sprite defaultSprite;

    [SerializeField]
    public Sprite[] roadSprites;

    public BuildController buildController;

    private SpriteRenderer sp;
    private GameObject child;

    public Tile tileTop;
    public Tile tileBottom;
    public Tile tileRight;
    public Tile tileLeft;
    private bool isRoad;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        GenerateStone();
    }

    private void GenerateStone()
    {
        int randomNumber = Random.Range(0, stonePrefabs.Length * 4);

        if (randomNumber < stonePrefabs.Length)
        {
            child = Instantiate(stonePrefabs[randomNumber], stonePos.position, Quaternion.identity, gameObject.transform);
        }
    }

    private void OnMouseDown()
    {
        if (!child && !EventSystem.current.IsPointerOverGameObject())
        {
            var selectedSprite = buildController.selectedSprite;
            var selectedBuild = buildController.selectedBuild;
            if (selectedSprite != null)
            {
                if (selectedSprite.isRoad)
                {
                    isRoad = true;
                }
                else
                {
                    isRoad = false;
                }
                sp.sprite = selectedSprite.sprite;
            }

            if (selectedBuild != null)
            {
                Vector3 pos = buildPose.position;
                pos += new Vector3(0, 0, -1);

                switch (selectedBuild.type)
                {
                    case BuildType.House:
                        if (ResourceChangeData.AddCoinsAction(-50))
                        {
                            child = Instantiate(selectedBuild.prefab, pos, Quaternion.identity, transform);
                            child.GetComponent<House>().buildController = buildController;
                            SetNotRoad();
                        };
                        break;
                    case BuildType.Factory:
                        if (ResourceChangeData.AddCoinsAction(-100))
                        {
                            child = Instantiate(selectedBuild.prefab, pos, Quaternion.identity, transform);
                            child.GetComponent<Factory>().buildController = buildController;
                            SetNotRoad();
                        };
                        break;
                    case BuildType.GeneratorWind:
                        if (ResourceChangeData.AddCoinsAction(-50))
                        {
                            Vector3 newWindPos = windMillPose.position;
                            newWindPos += new Vector3(0, 0, -1);
                            child = Instantiate(selectedBuild.prefab, newWindPos, Quaternion.identity, transform);
                            SetNotRoad();
                        };
                        break;
                    case BuildType.GeneratorSolar:
                        if (ResourceChangeData.AddCoinsAction(-25))
                        {
                            child = Instantiate(selectedBuild.prefab, pos, Quaternion.identity, transform);
                            SetNotRoad();
                        };
                        break;
                    case BuildType.Tree:
                        if (ResourceChangeData.AddCoinsAction(-10))
                        {
                            child = Instantiate(selectedBuild.prefab, pos, Quaternion.identity, transform);
                            SetNotRoad();
                        };
                        break;
                }
            }
        }

        this.RoadType();
        if (tileTop) { tileTop.RoadType(); };
        if (tileBottom) { tileBottom.RoadType(); };
        if (tileLeft) { tileLeft.RoadType(); };
        if (tileRight) { tileRight.RoadType(); };
    }

    private void SetNotRoad()
    {
        isRoad = false;
        sp.sprite = defaultSprite;
    }

    public void RoadType()
    {
        int count = 0;
        if (tileTop?.isRoad == true)
        {
            count += 1;
        }
        if (tileBottom?.isRoad == true)
        {
            count += 4;
        }
        if (tileLeft?.isRoad == true)
        {
            count += 8;
        }
        if (tileRight?.isRoad == true)
        {
            count += 2;
        }

        if (isRoad)
        {
            sp.sprite = roadSprites[count];
        }
    }
}
