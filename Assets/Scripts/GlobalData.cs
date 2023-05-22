using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    Energy,
    Coins,
    Polution,
    Population
}

public static class GlobalData
{
    public static int energy;
    public static int coins;
    public static int polution;
    public static int population;
}
