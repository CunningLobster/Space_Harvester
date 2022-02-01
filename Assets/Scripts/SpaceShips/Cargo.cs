using SpaceCarrier.Prefs;
using SpaceCarrier.Physics;
using SpaceCarrier.Resoures;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace SpaceCarrier.SpaceShips
{
    public class Cargo : MonoBehaviour
    {
        [SerializeField] ShipResoucePanel shipResoucePanel;
        [SerializeField] private int maxWeight = 1000;
        private int currentWeight = 0;

        private int credits;
        Dictionary<ResourceTypes, int> cargoResources = new Dictionary<ResourceTypes, int>();

        public UnityEvent onCapacityChanged;
        private Rigidbody rb;

        [SerializeField] private float shipMass = 1;

        #region PROPERTIES
        public Dictionary<ResourceTypes, int> CargoResources { get => cargoResources; private set => cargoResources = value; }
        public bool IsFull { get => currentWeight >= maxWeight; }
        #endregion

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();

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

        private void OnDisable()
        {
            onCapacityChanged?.RemoveAllListeners();
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
            onCapacityChanged?.Invoke();
            shipResoucePanel.UpdatePanel(cargoResources, credits);
            shipResoucePanel.UpdateWeightValue(currentWeight, maxWeight);
        }

        private void AddResources(ResourceTypes type, int resourceAmount, out int amountToAdd)
        {
            amountToAdd = Mathf.Min(resourceAmount, maxWeight - currentWeight);

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

        public void EarnRiskReward()
        {
            credits += currentWeight;
            PlayerPrefs.SetInt(PrefsKeys.creditsKey, credits);
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (Keyboard.current.lKey.wasPressedThisFrame)
            {
                Gravity[] celestialsOnScene = FindObjectsOfType<Gravity>();
                foreach (var celestial in celestialsOnScene)
                {
                    Debug.Log("added listeners");
                    onCapacityChanged?.AddListener(celestial.DefineDangerZone);
                }
            }

            if (Keyboard.current.rKey.wasPressedThisFrame)
                ResetResources();


            //print("Purple: " + PlayerPrefs.GetInt("Purple"));
            //print("Red: " + PlayerPrefs.GetInt("Red"));
            //print("Blue: " + PlayerPrefs.GetInt("Blue"));
            //print("Green: " + PlayerPrefs.GetInt("Green"));
            //print("Brown: " + PlayerPrefs.GetInt("Brown"));
        }
#endif
    }
}