using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceController : MonoBehaviour
{
    [SerializeField]
    private Text energyText;
    [SerializeField]
    private Text coinsText;
    [SerializeField]
    private Text polutionText;
    [SerializeField]
    private Text populationText;

    private void Awake()
    {
        ResourceChangeData.energy = 100;
        ResourceChangeData.coins = 1000;
        ResourceChangeData.polution = 0;
        ResourceChangeData.population = 0;
    }
    private void Start()
    {
        StartCoroutine(Economic());
        StartCoroutine(Actions());
    }

    public IEnumerator Economic()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);

            ResourceChangeData.energy += ResourceChangeData.energyChange;
            ResourceChangeData.coins += ResourceChangeData.coinsChange;
            ResourceChangeData.polution += ResourceChangeData.polutionChange;
            ResourceChangeData.population += ResourceChangeData.populationChange;
        }
    }

    public IEnumerator Actions()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            if (ResourceChangeData.energy < 0)
            {
                ResourceChangeData.energy = 0;
            }
            if (ResourceChangeData.coins < 0)
            {
                ResourceChangeData.coins = 0;
            }
            if (ResourceChangeData.polution < 0)
            {
                ResourceChangeData.polution = 0;
            }

            energyText.text = ResourceChangeData.energy.ToString();
            coinsText.text = ResourceChangeData.coins.ToString();
            polutionText.text = ResourceChangeData.polution.ToString();
            populationText.text = ResourceChangeData.population.ToString();
        }
    }
}
