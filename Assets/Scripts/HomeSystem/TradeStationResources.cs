using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceCarrier.HomeSystem
{
    public class TradeStationResources : MonoBehaviour
    {
        [SerializeField] private int purpleSellingCost;
        [SerializeField] private int redSellingCost;
        [SerializeField] private int blueSellingCost;
        [SerializeField] private int greenSellingCost;
        [SerializeField] private int brownSellingCost;

        [SerializeField] private float buySellRatio = 1.3f;

        [SerializeField] ResourcePanel buyingPart;
        [SerializeField] ResourcePanel sellingPart;

        private void Start()
        {
            sellingPart.UpdatePanel(purpleSellingCost, redSellingCost, blueSellingCost, greenSellingCost, brownSellingCost);
            buyingPart.UpdatePanel(GetBuyingCost(purpleSellingCost), GetBuyingCost(redSellingCost), GetBuyingCost(blueSellingCost),
                GetBuyingCost(greenSellingCost), GetBuyingCost(brownSellingCost));
        }

        int GetBuyingCost(int sellingCost)
        {
            return Mathf.FloorToInt((float)sellingCost * buySellRatio);
        }
    }
}