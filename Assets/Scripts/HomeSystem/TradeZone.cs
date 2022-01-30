using SpaceCarrier.Celestials;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceCarrier.HomeSystem
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

        ResourceTypes selectedResourceType;
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
            }
            selectedResourceType = type;
        }

        public void OnChangeBalance(int deltaResourceAmount)
        {
            Dictionary<ResourceTypes, TMPro.TMP_Text> panelResources = homeResourcePanel.PanelResources;

            string resourceValueString = panelResources[selectedResourceType].text;
            int.TryParse(resourceValueString, out int resourceValue);
            Debug.Log("resourceValueString" + resourceValueString);
            Debug.Log("resourceValue " + resourceValue);


            int newResourceValue = Mathf.Max(0, resourceValue + deltaResourceAmount);
            panelResources[selectedResourceType].text = newResourceValue.ToString();

            int newDelta = resourceValue - newResourceValue;

            if (deltaResourceAmount > 0)
            {
                balance += newDelta * tradeStationResources.ResourcesBuyingCosts[selectedResourceType];
                UpdateBalanceText();
            }
            else if (deltaResourceAmount < 0)
            {
                balance += newDelta * tradeStationResources.ResourcesSellingCosts[selectedResourceType];
                UpdateBalanceText();
            }
        }

        public void OnDealButton()
        {
            homeResources.Credits += balance;
            balance = 0;
            UpdateBalanceText();

            PlayerPrefs.SetInt(homeResources.CreditsKey, homeResources.Credits);

            Dictionary<ResourceTypes, TMP_Text> panelResources = homeResourcePanel.PanelResources;

            PlayerPrefs.SetInt(homeResources.H_purpleKey, int.Parse(panelResources[ResourceTypes.Purple].text));
            PlayerPrefs.SetInt(homeResources.H_redKey, int.Parse(panelResources[ResourceTypes.Red].text));
            PlayerPrefs.SetInt(homeResources.H_blueKey, int.Parse(panelResources[ResourceTypes.Blue].text));
            PlayerPrefs.SetInt(homeResources.H_greenKey, int.Parse(panelResources[ResourceTypes.Green].text));
            PlayerPrefs.SetInt(homeResources.H_brownKey, int.Parse(panelResources[ResourceTypes.Brown].text));

            homeResourcePanel.Credits.text = homeResources.Credits.ToString();
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
