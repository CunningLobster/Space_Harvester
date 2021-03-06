using TMPro;
using UnityEngine;

namespace SpaceCarrier.Resoures
{
    //Resource Panel but with weight value
    public class ShipResoucePanel : ResourcePanel
    {
        [SerializeField] private TMP_Text weight;

        public void UpdateWeightValue(float currentWeight, float maxWeight)
        {
            this.weight.text = $"{currentWeight} / {maxWeight}";
        }
    }
}
