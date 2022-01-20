using SpaceCarrier.SpaceShips;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcePanel : MonoBehaviour
{
    [SerializeField] TMP_Text white;
    [SerializeField] TMP_Text red;
    [SerializeField] TMP_Text blue;
    [SerializeField] TMP_Text green;
    [SerializeField] TMP_Text yellow;

    Cargo cargo;

    private void Awake()
    {
        cargo = FindObjectOfType<Harvester>().Cargo;
    }

    private void Update()
    {
        UpdateResourceAmount(white, cargo.White);
        UpdateResourceAmount(red, cargo.Red);
        UpdateResourceAmount(blue, cargo.Blue);
        UpdateResourceAmount(green, cargo.Green);
        UpdateResourceAmount(yellow, cargo.Yellow);
    }

    void UpdateResourceAmount(TMP_Text text, int resourceAmount)
    { 
        text.text = resourceAmount.ToString();
    }
}
