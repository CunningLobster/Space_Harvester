using SpaceCarrier.SpaceShips;
using TMPro;
using UnityEngine;

public class ShipResoucePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text credits;
    [SerializeField] private TMP_Text purple;
    [SerializeField] private TMP_Text red;
    [SerializeField] private TMP_Text blue;
    [SerializeField] private TMP_Text green;
    [SerializeField] private TMP_Text brown;
    [SerializeField] private TMP_Text weight;
    private Cargo cargo;

    private void Awake()
    {
        cargo = FindObjectOfType<Harvester>().Cargo;
    }

    private void Update()
    {
        UpdateResourceAmount(purple, cargo.Purple);
        UpdateResourceAmount(red, cargo.Red);
        UpdateResourceAmount(blue, cargo.Blue);
        UpdateResourceAmount(green, cargo.Green);
        UpdateResourceAmount(brown, cargo.Brown);
        weight.text = $"{cargo.CurrentCapacity}/{cargo.MaxCapacity}";
    }

    private void UpdateResourceAmount(TMP_Text text, int resourceAmount)
    {
        text.text = resourceAmount.ToString();
    }
}
