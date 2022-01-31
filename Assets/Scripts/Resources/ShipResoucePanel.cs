using TMPro;
using UnityEngine;

namespace SpaceCarrier.Resoures
{
    public class ShipResoucePanel : ResourcePanel
    {
        [SerializeField] private TMP_Text weight;

        public void UpdateWeightValue(int currentWeight, int maxWeight)
        {
            this.weight.text = $"{currentWeight} / {maxWeight}";
        }
    }
}
