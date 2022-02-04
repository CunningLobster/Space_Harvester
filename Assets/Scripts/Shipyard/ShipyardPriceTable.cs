using SpaceCarrier.ShipStats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceCarrier.Shipyard
{
    public class ShipyardPriceTable : MonoBehaviour
    {

        [SerializeField] private UpgradePriceDisplayer engineUPD;
        [SerializeField] private UpgradePriceDisplayer maneurabilityUPD;
        [SerializeField] private UpgradePriceDisplayer massUPD;
        [SerializeField] private UpgradePriceDisplayer cargoCapacityUPD;
        [SerializeField] private UpgradePriceDisplayer harvestingUPD;

        private Dictionary<Stats, UpgradePriceDisplayer> priceDisplayers = new Dictionary<Stats, UpgradePriceDisplayer>();
        public Dictionary<Stats, UpgradePriceDisplayer> PriceDisplayers { get => priceDisplayers; }

        List<Sprite> currentSprites = new List<Sprite>();
        List<int> currentPrices = new List<int>();

        [SerializeField] private Sprite creditsSprite;

        private void Awake()
        {
            priceDisplayers[Stats.Engine] = engineUPD;
            priceDisplayers[Stats.Maneurability] = maneurabilityUPD;
            priceDisplayers[Stats.Mass] = massUPD;
            priceDisplayers[Stats.CargoCapacity] = cargoCapacityUPD;
            priceDisplayers[Stats.Harvesting] = harvestingUPD;
        }

        private List<Sprite> GetCurrentSpriteSet(ShipStat stat, int priceIndex)
        {
            currentSprites.Clear();

            PriceSet currentPriceSet = stat.Prices[priceIndex];

            foreach (var item in currentPriceSet.resourceSet)
            {
                currentSprites.Add(item.resource.Sprite);
            }
            currentSprites.Add(creditsSprite);

            return currentSprites;
        }

        private List<int> GetCurrentPriceSet(ShipStat stat, int priceIndex)
        {
            currentPrices.Clear();

            PriceSet currentPriceSet = stat.Prices[priceIndex];
            int credits = currentPriceSet.credits;

            foreach (var item in currentPriceSet.resourceSet)
            {
                currentPrices.Add(item.value);
            }
            currentPrices.Add(credits);

            return currentPrices;
        }

        public void UpdatePriceTable(ShipStat stat, int priceIndex)
        {
            priceDisplayers[stat.Type].HideUpgradePrice(currentSprites, currentPrices);

            if (priceIndex > stat.Prices.Length - 1) return;

            GetCurrentPriceSet(stat, priceIndex);
            GetCurrentSpriteSet(stat, priceIndex);

            priceDisplayers[stat.Type].ShowUpgradePrice(currentSprites, currentPrices);
        }
    }
}
