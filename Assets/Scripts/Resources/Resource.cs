using SpaceCarrier.Resoures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "ScriptableObjects/SpawnResource", order = 2)]
public class Resource : ScriptableObject
{
    [SerializeField] private ResourceTypes type;
    [SerializeField] private Sprite sprite;
}
