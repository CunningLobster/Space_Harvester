using SpaceCarrier.HomeSystem;
using SpaceCarrier.SpaceShips;
using TMPro;
using UnityEngine;

public class ShipResoucePanel : ResourcePanel
{
    [SerializeField] private TMP_Text weight;

    public void UpdateWeightValue(int currentWeight, int maxWeight)
    {
        this.weight.text = $"{currentWeight} / {maxWeight}";
    }
}
