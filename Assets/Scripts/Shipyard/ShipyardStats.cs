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
    //Class is managing all operations in Shipyard
    public class ShipyardStats : MonoBehaviour
    {
        //Stats progress bar cells, will be wrapped in a dictionary
        [SerializeField] private Image[] engineProgressCells = new Image[10];
        [SerializeField] private Image[] maneurabilityProgressCells = new Image[10];
        [SerializeField] private Image[] massProgressCells = new Image[10];
        [SerializeField] private Image[] cargoCapacityProgressCells = new Image[10];
        [SerializeField] private Image[] harvestingProgressCells = new Image[10];

        //Cell is accepted when upgrades are accepted, Cell is reserved when upgrade was purchased but not accepted
        [SerializeField] private Sprite acceptedSprite;
        [SerializeField] private Sprite reservedSprite;

        //Wrap it in a dictionary
        [SerializeField] private ShipStat engine;
        [SerializeField] private ShipStat maneurability;
        [SerializeField] private ShipStat mass;
        [SerializeField] private ShipStat cargoCapacity;
        [SerializeField] private ShipStat harvesting;

        [SerializeField] ShipyardPriceTable priceTable;

        //Dictionaries for work with cells and stats
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

        //Current prices for upgrade to next stat level
        private void ShowCurrentPrices()
        {
            foreach (var key in stats.Keys.ToList())
            {
                priceTable.UpdatePriceTable(stats[key], stats[key].CurrentLevel);
            }
        }

        //Make cells accepted
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

        //Make cells reserved
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


        //When Upgrade button is pushed
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

            //Define price set for upgrade
            Dictionary<ResourceTypes, int> currentResoursePriceSet = chosenStat.ResourcePriceSets[chosenStat.Prices[lastActive - 1]];
            int currentCreditsPrice = chosenStat.CreditsPriceSet[chosenStat.Prices[lastActive - 1]];

            if (!AvailableToUpgrage(currentResoursePriceSet, currentCreditsPrice)) return;

            SubstractFromResourcePanel(currentResoursePriceSet, currentCreditsPrice);
            ReserveCell(type, chosenStat, lastActive);
        }

        //Substract stat current price set from appropriate resources in home resource panel
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

        //Check if player has enough resources to upgrade
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


        //Whe Accept button is pressed
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

        //When Reset button is pressed
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

        //Wrap stats in a dictionary
        private void DefineStats()
        {
            stats[Stats.Engine] = engine;
            stats[Stats.Maneurability] = maneurability;
            stats[Stats.Mass] = mass;
            stats[Stats.CargoCapacity] = cargoCapacity;
            stats[Stats.Harvesting] = harvesting;
        }

        //Wrap cells in a dictionry
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