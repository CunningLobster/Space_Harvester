using SpaceCarrier.ShipStats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceCarrier.Shipyard
{
    public class UpgradeButtonPanel : MonoBehaviour
    {
        [SerializeField] private Button engineUpgradeButton;
        [SerializeField] private Button maneurabilityUpgradeButton;
        [SerializeField] private Button massUpgradeButton;
        [SerializeField] private Button cargoCapacityUpgradeButton;
        [SerializeField] private Button harvestingUpgradeButton;

        [SerializeField] private ShipyardStats shipyardStats;

        private void OnEnable()
        {
            engineUpgradeButton.onClick.AddListener(delegate { shipyardStats.OnUpgradeStat(Stats.Engine); });
            maneurabilityUpgradeButton.onClick.AddListener(delegate { shipyardStats.OnUpgradeStat(Stats.Maneurability); });
            massUpgradeButton.onClick.AddListener(delegate { shipyardStats.OnUpgradeStat(Stats.Mass); });
            cargoCapacityUpgradeButton.onClick.AddListener(delegate { shipyardStats.OnUpgradeStat(Stats.CargoCapacity); });
            harvestingUpgradeButton.onClick.AddListener(delegate { shipyardStats.OnUpgradeStat(Stats.Harvesting); });
        }
        private void OnDisable()
        {
            engineUpgradeButton.onClick.RemoveAllListeners();
            maneurabilityUpgradeButton.onClick.RemoveAllListeners();
            massUpgradeButton.onClick.RemoveAllListeners();
            cargoCapacityUpgradeButton.onClick.RemoveAllListeners();
            harvestingUpgradeButton.onClick.RemoveAllListeners();
        }
    }
}