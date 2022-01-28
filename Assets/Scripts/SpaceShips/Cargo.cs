using SpaceCarrier.Celestials;
using SpaceCarrier.Physics;
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
        private int purple;
        private int red;
        private int blue;
        private int green;
        private int brown;

        public UnityEvent onCapacityChanged;

        #region RESOURCE_KEYS
        string s_creditsKey = "S_Credits_Key";
        string s_purpleKey = "S_Purple_Key";
        string s_redKey = "S_Red_Key";
        string s_blueKey = "S_Blue_Key";
        string s_greenKey = "S_Green_Key";
        string s_brownKey = "S_Brown_Key";
        #endregion

        #region PROPERTIES
        public int MaxCapacity { get => maxWeight; private set => maxWeight = value; }
        public int CurrentCapacity { get => currentWeight; private set => currentWeight = value; }

        public int Purple { get => purple; private set => purple = value; }
        public int Red { get => red; private set => red = value; }
        public int Blue { get => blue; private set => blue = value; }
        public int Green { get => green; private set => green = value; }
        public int Brown { get => brown; private set => brown = value; }
        #endregion

        private void Awake()
        {
            purple = PlayerPrefs.GetInt(s_purpleKey, 0);
            red = PlayerPrefs.GetInt(s_redKey, 0);
            blue = PlayerPrefs.GetInt(s_blueKey, 0);
            green = PlayerPrefs.GetInt(s_greenKey, 0);
            brown = PlayerPrefs.GetInt(s_brownKey, 0);
            currentWeight = CalculateCapacity();
        }

        private void Start()
        {
            if (shipResoucePanel == null) return;
            currentWeight = CalculateCapacity();
            shipResoucePanel.UpdatePanel(credits, purple, red, blue, green, brown);
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
                    purple += resourceAmount;
                    PlayerPrefs.SetInt(s_purpleKey, purple);
                    break;
                case ResourceTypes.Red:
                    red += resourceAmount;
                    PlayerPrefs.SetInt(s_redKey, red);
                    break;
                case ResourceTypes.Blue:
                    blue += resourceAmount;
                    PlayerPrefs.SetInt(s_blueKey, blue);
                    break;
                case ResourceTypes.Green:
                    green += resourceAmount;
                    PlayerPrefs.SetInt(s_greenKey, green);
                    break;
                case ResourceTypes.Brown:
                    brown += resourceAmount;
                    PlayerPrefs.SetInt(s_brownKey, brown);
                    break;
            }
            currentWeight = CalculateCapacity();
            onCapacityChanged?.Invoke();
            shipResoucePanel.UpdatePanel(credits, purple, red, blue, green, brown);
            shipResoucePanel.UpdateWeightValue(currentWeight, maxWeight);
        }

        public void ResetResources()
        {
            currentWeight = 0;
            purple = red = blue = green = brown = 0;
            PlayerPrefs.SetInt(s_purpleKey, purple);
            PlayerPrefs.SetInt(s_redKey, red);
            PlayerPrefs.SetInt(s_blueKey, blue);
            PlayerPrefs.SetInt(s_greenKey, green);
            PlayerPrefs.SetInt(s_brownKey, brown);
        }

        private int CalculateCapacity()
        {
            return purple + red + blue + green + brown;
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
    }
#endif
}