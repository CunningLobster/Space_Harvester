using SpaceCarrier.Prefs;
using SpaceCarrier.Resoures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceCarrier.ShipStats
{
    [CreateAssetMenu(fileName = "Stat", menuName = "ScriptableObjects/SpawnShipStat", order = 1)]
    public class ShipStat : ScriptableObject
    {
        [SerializeField] Stats type = Stats.Engine;
        [SerializeField] private float[] values = new float[10];

        [SerializeField] private int currentLevel;
        public int CurrentLevel { get => currentLevel; }

        [SerializeField] private PriceSet[] prices;

        private void Awake()
        {
            currentLevel = PlayerPrefs.GetInt(PrefsKeys.statsKeys[type], 0);
        }

        public void ChangeLevel(int value)
        { 
            PlayerPrefs.SetInt(PrefsKeys.statsKeys[type], value);
            currentLevel = value;
        }

        public float GetCurrentValue()
        { 
            return values[currentLevel];
        }
    }

    [System.Serializable]
    public struct PriceToUpgrade
    {
        public ResourceTypes type;
        public int value;
    }

    [System.Serializable]
    public struct PriceSet
    {
        public PriceToUpgrade[] set;
        public int credits;
    }
}