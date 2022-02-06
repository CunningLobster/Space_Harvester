using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceCarrier.SpaceShips;
using SpaceCarrier.UI;
using SpaceCarrier.Prefs;
using SpaceCarrier.Resoures;

namespace SpaceCarrier.Rewards
{
    public class RewardManager : MonoBehaviour
    { 
        static int collectedResources;

        float riskMultiplier = .5f;

        [SerializeField] Cargo cargo;
        [SerializeField] ShipResoucePanel shipResoucePanel;
        [SerializeField] UILogDisplayer logDisplayer;

        public static int CollectedResources { get => collectedResources; set => collectedResources = value; }

        private void Start()
        {
            PayRiskReward();
        }

        //Reward for jumping in a next system
        private void PayRiskReward()
        {
            if (collectedResources == 0) return;
            int reward = Mathf.CeilToInt(riskMultiplier * collectedResources * (collectedResources + cargo.CurrentWeight));
            
            PlayerPrefs.SetInt(PrefsKeys.creditsKey, cargo.Credits + reward);
            shipResoucePanel.UpdatePanel(cargo.CargoResources, cargo.Credits);
            logDisplayer.ShowRiskRewardLog(reward);

            collectedResources = 0;

        }
    }
}