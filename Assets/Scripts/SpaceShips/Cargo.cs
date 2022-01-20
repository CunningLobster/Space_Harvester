using SpaceCarrier.Celestials;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cargo", menuName = "ScriptableObjects/CreateCargo", order = 1)]
public class Cargo : ScriptableObject
{
    [SerializeField] int maxCapacity = 1000;
    public int currentCapacity = 0;

    public int White { get; private set; }
    public int Red { get; private set; }
    public int Blue { get; private set; }
    public int Green {get; private set; }
    public int Yellow {get; private set; }

    public void Fill(int resourceAmount, ResourceTypes type)
    {
        if (currentCapacity >= maxCapacity)
        {
            Debug.Log("Cargo is full");
            return;
        }

        switch (type)
        {
            case ResourceTypes.White:
                White += resourceAmount;
                break;
            case ResourceTypes.Red:
                Red += resourceAmount;
                break;
            case ResourceTypes.Blue:
                Blue += resourceAmount;
                break;
            case ResourceTypes.Green:
                Green += resourceAmount;
                break;
            case ResourceTypes.Yellow:
                Yellow += resourceAmount;
                break;
        }
        currentCapacity = White + Red + Blue + Green + Yellow;


        Debug.Log("Harvested: " + resourceAmount);
    }

    public void ResetResources()
    {
        currentCapacity = 0;
        White = 0;
        Red = 0;
        Green = 0;
        Yellow = 0;
        Blue = 0;
    }
}
