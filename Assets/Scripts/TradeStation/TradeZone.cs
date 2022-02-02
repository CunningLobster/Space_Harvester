using SpaceCarrier.HomeSystem;
using SpaceCarrier.Prefs;
using SpaceCarrier.Resoures;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceCarrier.TradeStation
{
    public class TradeZone : MonoBehaviour
    {
        [SerializeField] ResourcePanel homeResourcePanel;
        [SerializeField] HomeResources homeResources;
        [SerializeField] TradeStationResources tradeStationResources;

        [SerializeField] Image selectedResource;
        [SerializeField] Sprite purple;
        [SerializeField] Sprite red;
        [SerializeField] Sprite blue;
        [SerializeField] Sprite green;
        [SerializeField] Sprite brown;
        [SerializeField] Sprite none;

        ResourceTypes selectedResourceType = ResourceTypes.None;
        private int balance;
        [SerializeField] private TMP_Text balanceText;

        private void Start()
        {
            UpdateBalanceText();
        }

        public void OnSelectResource(ResourceTypes type)
        {
            switch (type)
            {
                case ResourceTypes.Purple:
                    selectedResource.sprite = purple;
                    break;
                case ResourceTypes.Red:
                    selectedResource.sprite = red;
                    break;
                case ResourceTypes.Blue:
                    selectedResource.sprite = blue;
                    break;
                case ResourceTypes.Green:
                    selectedResource.sprite = green;
                    break;
                case ResourceTypes.Brown:
                    selectedResource.sprite = brown;
                    break;
                case ResourceTypes.None:
                    selectedResource.sprite = none;
                    break;
            }
            selectedResourceType = type;
        }

        public void OnChangeBalance(int deltaResourceAmount)
        {
            if (selectedResourceType == ResourceTypes.None) return;

            Dictionary<ResourceTypes, TMP_Text> panelResources = homeResourcePanel.PanelResources;

            string resourceValueString = panelResources[selectedResourceType].text;
            int.TryParse(resourceValueString, out int resourceValue);

            int newResourceValue = Mathf.Max(0, resourceValue + deltaResourceAmount);

            int finalDelta = newResourceValue - resourceValue;

            for (int i = 1; i <= Mathf.Abs(finalDelta); i++)
            {
                //Buying
                if (deltaResourceAmount > 0)
                {
                    if (resourceValue >= homeResources.Resources[selectedResourceType])
                        balance -= tradeStationResources.ResourcesBuyingCosts[selectedResourceType];
                    else
                        balance -= tradeStationResources.ResourcesSellingCosts[selectedResourceType];
                    resourceValue++;
                }
                //Selling
                else if (deltaResourceAmount < 0)
                {

                    if (resourceValue <= homeResources.Resources[selectedResourceType])
                        balance += tradeStationResources.ResourcesSellingCosts[selectedResourceType];
                    else
                        balance += tradeStationResources.ResourcesBuyingCosts[selectedResourceType];
                    resourceValue--;
                }
            }
            panelResources[selectedResourceType].text = resourceValue.ToString();
            UpdateBalanceText();
        }

        public void OnDealButton()
        {
            if (homeResources.Credits + balance < 0) return;

            homeResources.Credits += balance;
            balance = 0;
            UpdateBalanceText();

            PlayerPrefs.SetInt(PrefsKeys.creditsKey, homeResources.Credits);

            Dictionary<ResourceTypes, TMP_Text> panelResources = homeResourcePanel.PanelResources;

            foreach (var key in PrefsKeys.homeResourcesKeys.Keys.ToList())
            {
                PlayerPrefs.SetInt(PrefsKeys.homeResourcesKeys[key], int.Parse(panelResources[key].text));
                homeResources.Resources[key] = int.Parse(panelResources[key].text);
            }

            homeResourcePanel.Credits.text = homeResources.Credits.ToString();

            homeResourcePanel.UpdatePanel(homeResources.Resources, homeResources.Credits);
        }

        public void OnResetButton()
        { 
            balance = 0;

            homeResourcePanel.UpdatePanel(homeResources.Resources);
            UpdateBalanceText();
        }

        public void OnSellAllButton()
        {
            ResourceTypes selected = selectedResourceType;

            var values = Enum.GetValues(typeof(ResourceTypes)).Cast<ResourceTypes>();
            foreach (var value in values)
            {
                OnSelectResource(value);
                OnChangeBalance(int.MinValue);
            }

            OnSelectResource(selected);
        }

        public void OnBack()
        {
            balance = 0;
            UpdateBalanceText();

            homeResourcePanel.UpdatePanel(homeResources.Resources, homeResources.Credits);
        }

        void UpdateBalanceText()
        {
            if (balance > 0)
                balanceText.text = $"+{balance}";
            else
                balanceText.text = balance.ToString();
        }
    }
}
