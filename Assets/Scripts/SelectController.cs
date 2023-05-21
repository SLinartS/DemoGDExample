using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public enum TypePrefab
{
    House,
    HouseRoof,
    Fabric,
    FabricRoof,
    FabricTube
}

public enum TypeFloor
{
    HouseFloor,
    FabricFloor
}

public class SelectController : MonoBehaviour
{
    public Sprite selectedSprite;
    public Sprite selectedRoadSprite;
    public Selected selectedPrefab;

    public void ClearSelected()
    {
        selectedPrefab = null;
        selectedRoadSprite = null;
        selectedSprite = null;
    }

    public void SelectTile(Sprite newSprite)
    {
        ClearSelected();
        selectedSprite = newSprite;
    }
    public void SelectRoadSprite(Sprite newRoadSprite)
    {
        ClearSelected();
        selectedRoadSprite = newRoadSprite;
    }

    public void SelectPrefab(GameObject newPrefab)
    {
        ClearSelected();
        selectedPrefab = new Selected(newPrefab);
    }
}

public class Selected
{
    public GameObject prefab;
    public TypePrefab type;

    public Selected(GameObject prefab)
    {
        this.prefab = prefab;
        switch (prefab.tag)
        {
            case "House":
                type = TypePrefab.House;
                break;
            case "HouseRoof":
                type = TypePrefab.HouseRoof;
                break;
            case "Fabric":
                type = TypePrefab.Fabric;
                break;
            case "FabricRoof":
                type = TypePrefab.FabricRoof;
                break;
            case "FabricTube":
                type = TypePrefab.FabricTube;
                break;
            default:
                throw new Exception("Error selected block type");
        }
    }
}