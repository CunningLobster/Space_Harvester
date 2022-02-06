using SpaceCarrier.Resoures;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SpaceCarrier.UI
{
    public class UILogDisplayer : MonoBehaviour
    {
        TMP_Text log;

        int harvested;

        private void Awake()
        {
            log = GetComponent<TMP_Text>();
        }

        public void ShowHarvestingLog(int amount, ResourceTypes type)
        {
            log.text = $"Harvested {harvested += amount} <sprite=\"game_resources\" name={type}>";
        }

        public void ShowHyperJumpLog(float time)
        {
            log.text = $"Hyperjump in {time} sec";
        }

        public void ShowRiskRewardLog(int reward)
        {
            log.text = $"Risk Reward: {reward} <sprite=\"game_resources\" name=\"Credits\">" ;
        }

        public void ClearLog()
        {
            Debug.Log("Clear");
            log.text = "";
            harvested = 0;
        }
    }
}