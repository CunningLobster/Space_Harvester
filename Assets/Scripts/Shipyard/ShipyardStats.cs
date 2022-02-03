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
            int lastActive = 0;
            for (int i = 0; i < progressCells[type].Length; i++)
            {
                if (!progressCells[type][i].gameObject.activeInHierarchy)
                {
                    progressCells[type][i].gameObject.SetActive(true);
                    break;
                }
                lastActive++;
            }

            priceTable.UpdatePriceTable(stats[type], lastActive);
        }

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