using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cargo", menuName = "ScriptableObjects/CreateCargo", order = 1)]
public class Cargo : ScriptableObject
{
    [SerializeField] int maxCapacity = 100;
    public int currentCapacity = 0;

    public void Fill(int resourceAmount)
    {
        if (currentCapacity >= maxCapacity)
        {
            Debug.Log("Cargo is full");
            return;
        }

        currentCapacity += resourceAmount;
        Debug.Log("Harvested: " + resourceAmount);
    }
}
