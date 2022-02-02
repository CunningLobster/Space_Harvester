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

        [SerializeField] private ShipStat engine;
        [SerializeField] private ShipStat maneurability;
        [SerializeField] private ShipStat mass;
        [SerializeField] private ShipStat cargoCapacity;
        [SerializeField] private ShipStat harvesting;

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
        }

        private void ActivateCells()
        {
            foreach (var key in stats.Keys.ToList())
            {
                for (int i = 0; i < stats[key].CurrentLevel + 1; i++)
                {
                    progressCells[key][i].gameObject.SetActive(true);
                }
            }
        }

        public void OnUpgradeStat(Stats type)
        {
            int nextLevel = stats[type].CurrentLevel + 1;

            if (nextLevel > progressCells[type].Length) return;
            stats[type].ChangeLevel(nextLevel);
            progressCells[type][nextLevel].gameObject.SetActive(true);

            ActivateCells();
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