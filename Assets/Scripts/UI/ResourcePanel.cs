using SpaceCarrier.SpaceShips;
using TMPro;
using UnityEngine;

public class ResourcePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text white;
    [SerializeField] private TMP_Text red;
    [SerializeField] private TMP_Text blue;
    [SerializeField] private TMP_Text green;
    [SerializeField] private TMP_Text yellow;
    [SerializeField] private TMP_Text capacity;
    private Cargo cargo;

    private void Awake()
    {
        cargo = FindObjectOfType<Harvester>().Cargo;
    }

    private void Update()
    {
        UpdateResourceAmount(white, cargo.Purple);
        UpdateResourceAmount(red, cargo.Red);
        UpdateResourceAmount(blue, cargo.Blue);
        UpdateResourceAmount(green, cargo.Green);
        UpdateResourceAmount(yellow, cargo.Brown);
        capacity.text = $"{cargo.CurrentCapacity}/{cargo.MaxCapacity}";
    }

    private void UpdateResourceAmount(TMP_Text text, int resourceAmount)
    {
        text.text = resourceAmount.ToString();
    }
}
