using SpaceCarrier.ShipStats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceCarrier.Shipyard
{
    public class ShipyardPriceTable : MonoBehaviour
    {
        [SerializeField] private ShipStat engine;
        [SerializeField] private ShipStat maneurability;
        [SerializeField] private ShipStat mass;
        [SerializeField] private ShipStat cargoCapacity;
        [SerializeField] private ShipStat harvesting;

        [SerializeField] private UpgradePriceDisplayer upgradePriceDisplayer;

        private void Start()
        {
        }

        private List<Sprite> GetCurrentSpriteSet(ShipStat stat)
        {
            List<Sprite> currentSprites = new List<Sprite>();

            PriceSet currentPriceSet = stat.Prices[engine.CurrentLevel];

            foreach (var item in currentPriceSet.set)
            {
                currentSprites.Add(item.resource.Sprite);
            }
            return currentSprites;
        }

        private List<int> GetCurrentPriceSet(ShipStat stat)
        {
            List<int> currentPrices = new List<int>();

            PriceSet currentPriceSet = stat.Prices[engine.CurrentLevel];

            foreach (var item in currentPriceSet.set)
            {
                currentPrices.Add(item.value);
            }
            return currentPrices;
        }
    }
}
