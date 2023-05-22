using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceController : MonoBehaviour
{
    public int energy = 100;
    public int coins = 1000;
    public int polution = 0;
    public int population = 0;

    [SerializeField] Text energyText;
    [SerializeField] Text coinsText;
    [SerializeField] Text polutionText;
    [SerializeField] Text populationText;

    void Start()
    {
        StartCoroutine(ResourceCount());
    }

    IEnumerator ResourceCount()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            energy += GlobalData.energy;
            coins += GlobalData.coins;
            polution += GlobalData.polution;
            population = GlobalData.population;            

            if (energy <= 0)
            {
                energy = 0;
            }
            if (polution <= 0)
            {
                polution = 0;
            }

            energyText.text = energy.ToString();
            coinsText.text = coins.ToString();
            polutionText.text = polution.ToString();
            populationText.text = population.ToString();

        } 
    }
}
