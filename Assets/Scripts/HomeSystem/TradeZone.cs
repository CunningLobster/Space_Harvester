using SpaceCarrier.Celestials;
using System.Collections;
using System.Collections.Generic;
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

        [SerializeField] Button purpleButton;

        ResourceTypes selectedResourceType;
        private int balance;

        private void Start()
        {
            purpleButton.onClick.AddListener(delegate { OnSelectResource(ResourceTypes.Purple); });
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

        public void OnChangeBalance(int resourceAmount)
        {
            
        }
    }
}
