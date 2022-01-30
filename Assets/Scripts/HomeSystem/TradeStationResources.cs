using SpaceCarrier.Celestials;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        Dictionary<ResourceTypes, int> resourcesSellingCosts = new Dictionary<ResourceTypes, int>(); 
        Dictionary<ResourceTypes, int> resourcesBuyingCosts = new Dictionary<ResourceTypes, int>(); 

        [SerializeField] private float buySellRatio = 1.3f;

        [SerializeField] ResourcePanel buyingPart;
        [SerializeField] ResourcePanel sellingPart;

        private void Awake()
        {
            resourcesSellingCosts[ResourceTypes.Purple] = purpleSellingCost;
            resourcesSellingCosts[ResourceTypes.Red] = redSellingCost;
            resourcesSellingCosts[ResourceTypes.Blue] = blueSellingCost;
            resourcesSellingCosts[ResourceTypes.Green] = greenSellingCost;
            resourcesSellingCosts[ResourceTypes.Brown] = brownSellingCost;

            resourcesBuyingCosts = GetBuyingCosts(resourcesSellingCosts);
        }
        private void Start()
        {
            sellingPart.UpdatePanel(resourcesSellingCosts);
            buyingPart.UpdatePanel(resourcesBuyingCosts);
        }

        Dictionary<ResourceTypes, int> GetBuyingCosts(Dictionary<ResourceTypes, int> sellingCosts)
        {
            Dictionary<ResourceTypes, int> buyingCosts = new Dictionary<ResourceTypes, int>();

            foreach(var key in sellingCosts.Keys.ToList())
            {
                buyingCosts[key] = Mathf.FloorToInt((float)sellingCosts[key] * buySellRatio); 
            }
            return buyingCosts;
        }
    }
}