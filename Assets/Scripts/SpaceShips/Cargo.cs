using SpaceCarrier.Celestials;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    [SerializeField] int maxCapacity = 1000;
    public int currentCapacity = 0;

    public int Purple { get => PlayerPrefs.GetInt("Purple", 0); private set => PlayerPrefs.SetInt("Purple", value); }
    public int Red { get => PlayerPrefs.GetInt("Red", 0); private set => PlayerPrefs.SetInt("Red", value); }
    public int Blue { get => PlayerPrefs.GetInt("Blue", 0); private set => PlayerPrefs.SetInt("Blue", value); }
    public int Green { get => PlayerPrefs.GetInt("Green", 0); private set => PlayerPrefs.SetInt("Green", value); }
    public int Brown { get => PlayerPrefs.GetInt("Brown", 0); private set => PlayerPrefs.SetInt("Brown", value); }

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
    }

    public void ResetResources()
    {
        currentCapacity = 0;
        //Purple = 0
        PlayerPrefs.SetInt("Purple", 0);
        PlayerPrefs.SetInt("Red", 0);
        PlayerPrefs.SetInt("Green", 0);
        PlayerPrefs.SetInt("Brown", 0);
        PlayerPrefs.SetInt("Blue", 0);
        //Red = 0;
        //Green = 0;
        //Brown = 0;
        //Blue = 0;
    }
}
