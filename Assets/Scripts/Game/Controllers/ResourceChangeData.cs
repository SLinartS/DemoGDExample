using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceChangeData
{
    public static int energy;
    public static int energyChange;

    public static int coins;
    public static int coinsChange;

    public static int polution;
    public static int polutionChange;

    public static int population;
    public static int populationChange;

    public static bool AddEnergyAction(int value)
    {
        if (value < 0 && energy + value < 0)
        {
            return false;
        }
        energy += value;
        return true;
    }
    public static bool AddCoinsAction(int value)
    {
        if (value < 0 && coins + value < 0)
        {
            return false;
        }
        coins += value;
        return true;
    }
    public static bool AddPolutionAction(int value)
    {
        if (value < 0 && polution + value < 0)
        {
            return false;
        }
        polution += value;
        return true;
    }
    public static bool AddPopulationAction(int value)
    {
        if (value < 0 && population + value < 0)
        {
            return false;
        }
        population += value;
        return true;
    }

    public static bool AddCoinsAndPopulationAction(int valueCoins, int valuePopulation)
    {
        if ((valueCoins < 0 || valuePopulation < 0) && (coins + valueCoins < 0 || population + valuePopulation < 0))
        {
            return false;
        }
        coins += valueCoins;
        population += valuePopulation;
        return true;
    }

}
