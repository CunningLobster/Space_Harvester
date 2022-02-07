using SpaceCarrier.Prefs;
using SpaceCarrier.Physics;
using SpaceCarrier.Resoures;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using SpaceCarrier.ShipStats;

namespace SpaceCarrier.SpaceShips
{
    public class Cargo : MonoBehaviour
    {
        private Rigidbody rb;

        private float shipMass;
        private float maxWeight;
        private int currentWeight;

        [SerializeField] private ShipStat mass;
        [SerializeField] private ShipStat cargoCapacity;


        [SerializeField] ShipResoucePanel shipResoucePanel;
        private int credits;
        Dictionary<ResourceTypes, int> cargoResources = new Dictionary<ResourceTypes, int>();


        #region PROPERTIES
        public Dictionary<ResourceTypes, int> CargoResources { get => cargoResources; private set => cargoResources = value; }
        public bool IsFull { get => currentWeight >= maxWeight; }
        public int CurrentWeight { get => currentWeight; }
        public int Credits { get => credits; }
        #endregion

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();

            shipMass = mass.GetCurrentValue();
            maxWeight = cargoCapacity.GetCurrentValue();

            credits = PlayerPrefs.GetInt(PrefsKeys.creditsKey, 0);

            foreach (var key in PrefsKeys.shipResourcesKeys.Keys.ToList())
            {
                cargoResources[key] = PlayerPrefs.GetInt(PrefsKeys.shipResourcesKeys[key], 0);
            }

            currentWeight = CalculateWeight();
        }

        private void Start()
        {
            if (shipResoucePanel == null) return;
            shipResoucePanel.UpdatePanel(cargoResources, credits);
            shipResoucePanel.UpdateWeightValue(currentWeight, maxWeight);
        }

        public void Fill(int resourceAmount, ResourceTypes type, out int amountToFill)
        {
            if (currentWeight >= maxWeight)
            {
                Debug.Log("Cargo is full");
                amountToFill = 0;
                return;
            }

            AddResources(type, resourceAmount, out int amountToAdd);
            amountToFill = amountToAdd;

            currentWeight = CalculateWeight();
            shipResoucePanel.UpdatePanel(cargoResources);
            shipResoucePanel.UpdateWeightValue(currentWeight, maxWeight);
        }

        private void AddResources(ResourceTypes type, int resourceAmount, out int amountToAdd)
        {
            amountToAdd = Mathf.Min(resourceAmount, (int)maxWeight - currentWeight);

            cargoResources[type] += amountToAdd;
            PlayerPrefs.SetInt(PrefsKeys.shipResourcesKeys[type], cargoResources[type]);
        }

        public void ResetResources()
        {
            currentWeight = 0;
            foreach (var key in PrefsKeys.shipResourcesKeys.Keys.ToList())
            {
                PlayerPrefs.SetInt(PrefsKeys.shipResourcesKeys[key], 0);
                cargoResources[key] = PlayerPrefs.GetInt(PrefsKeys.shipResourcesKeys[key], 0);
            }

            currentWeight = CalculateWeight();
            shipResoucePanel?.UpdateWeightValue(currentWeight, maxWeight);
            shipResoucePanel?.UpdatePanel(cargoResources, credits);
        }

        private int CalculateWeight()
        {
            int totalWeight = 0;
            foreach (var key in cargoResources.Keys.ToList())
            {
                totalWeight += cargoResources[key];
            }

            rb.mass = shipMass + (float)totalWeight / 1000f;
            return totalWeight;
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
                ResetResources();
        }
#endif
    }
}