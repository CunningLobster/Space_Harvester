using SpaceCarrier.Prefs;
using SpaceCarrier.Resoures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceCarrier.ShipStats
{
    [CreateAssetMenu(fileName = "Stat", menuName = "ScriptableObjects/SpawnShipStat", order = 1)]
    public class ShipStat : ScriptableObject
    {
        [SerializeField] Stats type = Stats.Engine;
        [SerializeField] private float[] values = new float[10];
        [SerializeField] private int currentLevel;
        [SerializeField] private PriceSet[] prices;

        Dictionary<PriceSet, Dictionary<ResourceTypes, int>> resourcePriceSets = new Dictionary<PriceSet, Dictionary<ResourceTypes,int>>();
        Dictionary<PriceSet, int> creditsPriceSet = new Dictionary<PriceSet, int>();


        public Dictionary<PriceSet, Dictionary<ResourceTypes, int>> ResourcePriceSets { get => resourcePriceSets; }
        public Dictionary<PriceSet, int> CreditsPriceSet { get => creditsPriceSet; }
        public Stats Type { get => type; }
        public int CurrentLevel { get => currentLevel; }
        public PriceSet[] Prices { get => prices; }

        private void Awake()
        {
            currentLevel = PlayerPrefs.GetInt(PrefsKeys.statsKeys[type], 0);
            WrapPriceSets();
        }

        public void ChangeLevel(int value)
        { 
            PlayerPrefs.SetInt(PrefsKeys.statsKeys[type], value);
            currentLevel = value;
        }

        public float GetCurrentValue()
        { 
            return values[currentLevel];
        }

        public void WrapPriceSets()
        {
            foreach (PriceSet price in prices)
            {
                Dictionary<ResourceTypes, int> resourcePrices = new Dictionary<ResourceTypes, int>();

                foreach (var resourcePrice in price.resourceSet)
                {
                    resourcePrices[resourcePrice.resource.Type] = resourcePrice.value;
                }

                resourcePriceSets[price] = resourcePrices;
                creditsPriceSet[price] = price.credits;
            }

        }
    }

    [System.Serializable]
    public struct ResourcePrice
    {
        public Resource resource;
        public int value;
    }

    [System.Serializable]
    public struct PriceSet
    {
        public ResourcePrice[] resourceSet;
        public int credits;
    }
}