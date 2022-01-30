using SpaceCarrier.Celestials;
using SpaceCarrier.Physics;
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

        #region RESOURCE_KEYS
        string creditsKey = "Credits_Key";
        string s_purpleKey = "S_Purple_Key";
        string s_redKey = "S_Red_Key";
        string s_blueKey = "S_Blue_Key";
        string s_greenKey = "S_Green_Key";
        string s_brownKey = "S_Brown_Key";
        #endregion

        #region PROPERTIES
        public int MaxCapacity { get => maxWeight; private set => maxWeight = value; }
        public int CurrentCapacity { get => currentWeight; private set => currentWeight = value; }
        public Dictionary<ResourceTypes, int> CargoResources { get => cargoResources; private set => cargoResources = value; }
        #endregion

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();

            credits = PlayerPrefs.GetInt(creditsKey, 0);
            cargoResources[ResourceTypes.Purple] = PlayerPrefs.GetInt(s_purpleKey, 0);
            cargoResources[ResourceTypes.Red] = PlayerPrefs.GetInt(s_redKey, 0);
            cargoResources[ResourceTypes.Blue] = PlayerPrefs.GetInt(s_blueKey, 0);
            cargoResources[ResourceTypes.Green] = PlayerPrefs.GetInt(s_greenKey, 0);
            cargoResources[ResourceTypes.Brown] = PlayerPrefs.GetInt(s_brownKey, 0);
            currentWeight = CalculateWeight();
        }

        private void Start()
        {
            if (shipResoucePanel == null) return;
            currentWeight = CalculateWeight();
            shipResoucePanel.UpdatePanel(cargoResources, credits);
            shipResoucePanel.UpdateWeightValue(currentWeight, maxWeight);
        }

        private void OnDisable()
        {
            onCapacityChanged?.RemoveAllListeners();
        }

        public void Fill(int resourceAmount, ResourceTypes type)
        {
            if (currentWeight >= maxWeight)
            {
                Debug.Log("Cargo is full");
                return;
            }

            switch (type)
            {
                case ResourceTypes.Purple:
                    cargoResources[ResourceTypes.Purple] += resourceAmount;
                    PlayerPrefs.SetInt(s_purpleKey, cargoResources[ResourceTypes.Purple]);
                    break;
                case ResourceTypes.Red:
                    cargoResources[ResourceTypes.Red] += resourceAmount;
                    PlayerPrefs.SetInt(s_redKey, cargoResources[ResourceTypes.Red]);
                    break;
                case ResourceTypes.Blue:
                    cargoResources[ResourceTypes.Blue] += resourceAmount;
                    PlayerPrefs.SetInt(s_blueKey, cargoResources[ResourceTypes.Blue]);
                    break;
                case ResourceTypes.Green:
                    cargoResources[ResourceTypes.Green] += resourceAmount;
                    PlayerPrefs.SetInt(s_greenKey, cargoResources[ResourceTypes.Green]);
                    break;
                case ResourceTypes.Brown:
                    cargoResources[ResourceTypes.Brown] += resourceAmount;
                    PlayerPrefs.SetInt(s_brownKey, cargoResources[ResourceTypes.Brown]);
                    break;
            }
            currentWeight = CalculateWeight();
            onCapacityChanged?.Invoke();
            shipResoucePanel.UpdatePanel(cargoResources, credits);
            shipResoucePanel.UpdateWeightValue(currentWeight, maxWeight);
        }

        public void ResetResources()
        {
            currentWeight = 0;
            foreach (var key in cargoResources.Keys.ToList())
            {
                cargoResources[key] = 0;
            }
            PlayerPrefs.SetInt(s_purpleKey, cargoResources[ResourceTypes.Purple]);
            PlayerPrefs.SetInt(s_redKey, cargoResources[ResourceTypes.Red]);
            PlayerPrefs.SetInt(s_blueKey, cargoResources[ResourceTypes.Blue]);
            PlayerPrefs.SetInt(s_greenKey, cargoResources[ResourceTypes.Green]);
            PlayerPrefs.SetInt(s_brownKey, cargoResources[ResourceTypes.Brown]);

            shipResoucePanel?.UpdatePanel(cargoResources, credits);
        }

        private int CalculateWeight()
        {
            int totalWeight = 0;
            foreach (var key in cargoResources.Keys.ToList())
            {
                totalWeight += cargoResources[key];
            }

            rb.mass = 1 + (float)totalWeight / 1000f;
            return totalWeight;
        }

        public void EarnRiskReward()
        {
            credits += currentWeight;
            PlayerPrefs.SetInt(creditsKey, credits);
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