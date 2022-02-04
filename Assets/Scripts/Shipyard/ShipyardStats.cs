using SpaceCarrier.HomeSystem;
using SpaceCarrier.Prefs;
using SpaceCarrier.Resoures;
using SpaceCarrier.ShipStats;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceCarrier.Shipyard
{
    public class ShipyardStats : MonoBehaviour
    {
        [SerializeField] private Image[] engineProgressCells = new Image[10];
        [SerializeField] private Image[] maneurabilityProgressCells = new Image[10];
        [SerializeField] private Image[] massProgressCells = new Image[10];
        [SerializeField] private Image[] cargoCapacityProgressCells = new Image[10];
        [SerializeField] private Image[] harvestingProgressCells = new Image[10];

        [SerializeField] private Sprite acceptedSprite;
        [SerializeField] private Sprite reservedSprite;

        [SerializeField] private ShipStat engine;
        [SerializeField] private ShipStat maneurability;
        [SerializeField] private ShipStat mass;
        [SerializeField] private ShipStat cargoCapacity;
        [SerializeField] private ShipStat harvesting;

        [SerializeField] ShipyardPriceTable priceTable;

        Dictionary<Stats, Image[]> progressCells = new Dictionary<Stats, Image[]>();
        Dictionary<Stats,ShipStat> stats = new Dictionary<Stats, ShipStat>();

        [SerializeField] ResourcePanel homeResourcePanel;
        [SerializeField] HomeResources homeResources;

        private void Awake()
        {
            DefineProgressCells();
            DefineStats();
        }

        private void Start()
        {
            ActivateCells();
            ShowCurrentPrices();
        }

        private void ShowCurrentPrices()
        {
            foreach (var key in stats.Keys.ToList())
            {
                priceTable.UpdatePriceTable(stats[key], stats[key].CurrentLevel);
            }
        }

        private void ActivateCells()
        {
            foreach (var key in stats.Keys.ToList())
            {
                for (int i = 0; i < stats[key].CurrentLevel + 1; i++)
                {
                    progressCells[key][i].gameObject.SetActive(true);
                    progressCells[key][i].sprite = acceptedSprite;
                }
            }
        }

        public void OnUpgradeStat(Stats type)
        {
            ShipStat chosenStat = stats[type];
            int lastActive = 0;

            for (int i = 0; i < progressCells[type].Length; i++)
            {
                if (!progressCells[type][i].gameObject.activeInHierarchy)
                {
                    break;
                }

                lastActive++;
            }

            Dictionary<ResourceTypes, int> currentResoursePriceSet = chosenStat.ResourcePriceSets[chosenStat.Prices[lastActive - 1]];
            int currentCreditsPrice = chosenStat.CreditsPriceSet[chosenStat.Prices[lastActive - 1]];

            if (!AvailableToUpgrage(currentResoursePriceSet, currentCreditsPrice)) return;

            SubstractFromResourcePanel(currentResoursePriceSet, currentCreditsPrice);
            ReserveCell(type, chosenStat, lastActive);
        }

        private void ReserveCell(Stats type, ShipStat chosenStat, int lastActive)
        {
            for (int i = 0; i < progressCells[type].Length; i++)
            {
                if (!progressCells[type][i].gameObject.activeInHierarchy)
                {
                    progressCells[type][i].gameObject.SetActive(true);
                    break;
                }
            }

            priceTable.UpdatePriceTable(chosenStat, lastActive);
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void SubstractFromResourcePanel(Dictionary<ResourceTypes, int> currentResoursePriceSet, int currentCreditsPrice)
        {

            int panelResourceCredits = int.Parse(homeResourcePanel.Credits.text);

            foreach (var key in currentResoursePriceSet.Keys.ToList())
            {
                int panelResourceValue = int.Parse(homeResourcePanel.PanelResources[key].text);
                panelResourceValue -= currentResoursePriceSet[key];
                homeResourcePanel.PanelResources[key].text = panelResourceValue.ToString();
            }

            panelResourceCredits -= currentCreditsPrice;

            homeResourcePanel.Credits.text = panelResourceCredits.ToString();
        }

        private bool AvailableToUpgrage(Dictionary<ResourceTypes, int> currentResoursePriceSet, int currentCreditsPrice)
        {
            foreach (var key in currentResoursePriceSet.Keys.ToList())
            {
                int panelResourceValue = int.Parse(homeResourcePanel.PanelResources[key].text);
                if (panelResourceValue < currentResoursePriceSet[key])
                {
                    return false;
                }
            }

            int panelResourceCredits = int.Parse(homeResourcePanel.Credits.text);
            if (panelResourceCredits < currentCreditsPrice)
            {
                return false;
            }

            return true;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
        public void OnAccept()
        {

            foreach (var key in progressCells.Keys.ToList())
            {
                int lastActive = 0;
                for (int i = 1; i < progressCells[key].Length; i++)
                {
                    if (!progressCells[key][i].gameObject.activeInHierarchy)
                    {
                        break;
                    }
                    lastActive++;

                    if(progressCells[key][i].sprite != acceptedSprite)
                        progressCells[key][i].sprite = acceptedSprite;
                }
                stats[key].ChangeLevel(lastActive);
            }

            foreach (var key in PrefsKeys.homeResourcesKeys.Keys.ToList())
            {
                PlayerPrefs.SetInt(PrefsKeys.homeResourcesKeys[key], int.Parse(homeResourcePanel.PanelResources[key].text));
                homeResources.Resources[key] = int.Parse(homeResourcePanel.PanelResources[key].text);
            }
            homeResources.Credits = int.Parse(homeResourcePanel.Credits.text);
            homeResourcePanel.UpdatePanel(homeResources.Resources, homeResources.Credits);
        }

        public void OnReset()
        {
            foreach (var key in progressCells.Keys.ToList())
            {
                for (int i = 1; i < progressCells[key].Length; i++)
                {
                    if (!progressCells[key][i].gameObject.activeInHierarchy) break;
                    if (progressCells[key][i].gameObject.activeInHierarchy && progressCells[key][i].sprite == reservedSprite)
                        progressCells[key][i].gameObject.SetActive(false);
                }
            }

            ShowCurrentPrices();
            homeResourcePanel.UpdatePanel(homeResources.Resources, homeResources.Credits);
        }

        private void DefineStats()
        {
            stats[Stats.Engine] = engine;
            stats[Stats.Maneurability] = maneurability;
            stats[Stats.Mass] = mass;
            stats[Stats.CargoCapacity] = cargoCapacity;
            stats[Stats.Harvesting] = harvesting;
        }

        private void DefineProgressCells()
        {
            progressCells[Stats.Engine] = engineProgressCells;
            progressCells[Stats.Maneurability] = maneurabilityProgressCells;
            progressCells[Stats.Mass] = massProgressCells;
            progressCells[Stats.CargoCapacity] = cargoCapacityProgressCells;
            progressCells[Stats.Harvesting] = harvestingProgressCells;
        }
    }
}