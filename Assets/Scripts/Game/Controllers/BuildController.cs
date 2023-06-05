using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    [HideInInspector]
    public SelectedSprite selectedSprite;
    [HideInInspector]
    public SelectedBuild selectedBuild;

    public void SelectSprite(Sprite sprite)
    {
        this.selectedSprite = new SelectedSprite(sprite, false);
    }

    public void SelectRoadSprite(Sprite sprite)
    {
        this.selectedSprite = new SelectedSprite(sprite, true);
    }

    public void SelectBuild(GameObject prefab)
    {
        this.selectedBuild = new SelectedBuild(prefab);
    }
}


public class SelectedBuild
{
    public GameObject prefab;
    public BuildType type;
    public SelectedBuild(GameObject prefab)
    {
        this.prefab = prefab;
        this.type = prefab.GetComponent<Parameters>().buildType;
    }
}

public class SelectedSprite
{
    public Sprite sprite;
    public bool isRoad;

    public SelectedSprite(Sprite sprite, bool isRoad)
    {
        this.sprite = sprite;
        this.isRoad = isRoad;
    }
}
