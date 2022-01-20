using SpaceCarrier.Celestials;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cargo", menuName = "ScriptableObjects/CreateCargo", order = 1)]
public class Cargo : ScriptableObject
{
    [SerializeField] int maxCapacity = 1000;
    public int currentCapacity = 0;

    public int Purple { get; private set; }
    public int Red { get; private set; }
    public int Blue { get; private set; }
    public int Green {get; private set; }
    public int Brown {get; private set; }

    public void Fill(int resourceAmount, ResourceTypes type)
    {
        if (currentCapacity >= maxCapacity)
        {
            Debug.Log("Cargo is full");
            return;
        }

        switch (type)
        {
            case ResourceTypes.Purple:
                Purple += resourceAmount;
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
            case ResourceTypes.Brown:
                Brown += resourceAmount;
                break;
        }
        currentCapacity = Purple + Red + Blue + Green + Brown;


        Debug.Log("Harvested: " + resourceAmount);
    }

    public void ResetResources()
    {
        currentCapacity = 0;
        Purple = 0;
        Red = 0;
        Green = 0;
        Brown = 0;
        Blue = 0;
    }
}
