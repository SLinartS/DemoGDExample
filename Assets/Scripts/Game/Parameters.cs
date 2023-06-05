using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildType
{
    House,
    HouseFoor,
    HouseRoof,
    Factory,
    FactoryFloor,
    FactoryRoof,
    FactoryTube,
    GeneratorWind,
    GeneratorSolar,
    Tree,
}

public class Parameters : MonoBehaviour
{
    public BuildType buildType;
}
