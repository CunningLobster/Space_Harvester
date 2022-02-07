using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceCarrier.SpaceShips;
using SpaceCarrier.UI;
using SpaceCarrier.Prefs;
using SpaceCarrier.Resoures;

namespace SpaceCarrier.Rewards
{
    //Rewards is needed to stimulate player jumping into next system
    //Extra rewards will be added in the next versions
    public class RewardManager : MonoBehaviour
    { 
        static int collectedResources;

        private static int reward;
        [SerializeField] float riskMultiplier = .5f;

        [SerializeField] Cargo cargo;
        [SerializeField] ShipResoucePanel shipResoucePanel;
        [SerializeField] UILogDisplayer logDisplayer;

        private void Start()
        {
            PayRiskReward();
        }

        //OnWormholeJump
        public void CalculateRiskReward()
        {
            if (collectedResources == 0) return;
            reward = Mathf.CeilToInt(riskMultiplier * collectedResources * (collectedResources + cargo.CurrentWeight));

            PlayerPrefs.SetInt(PrefsKeys.creditsKey, cargo.Credits + reward);
        }

        //Reward for jumping in a next system
        private void PayRiskReward()
        {
            if (reward == 0) return;

            shipResoucePanel.UpdatePanel(cargo.CargoResources, cargo.Credits);
            logDisplayer.ShowRiskRewardLog(reward);

            collectedResources = 0;
            reward = 0;
        }

        public static void CollectResources(int amount)
        {
            collectedResources += amount;
        }

        public static void ResetCollectedResources()
        { 
            collectedResources = 0;
        }
    }
}