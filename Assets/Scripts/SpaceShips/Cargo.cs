using SpaceCarrier.Celestials;
using SpaceCarrier.Physics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace SpaceCarrier.SpaceShips
{
    public class Cargo : MonoBehaviour
    {
        [SerializeField] private int maxCapacity = 1000;
        private int currentCapacity = 0;

        private int purple;
        private int red;
        private int blue;
        private int green;
        private int brown;

        //delegate void OnCapacityChanged;
        //event OnCapacityChanged onCapacityChanged;
        public UnityEvent onCapacityChanged;

        #region PROPERTIES
        public int MaxCapacity { get => maxCapacity; private set => maxCapacity = value; }
        public int CurrentCapacity { get => currentCapacity; private set => currentCapacity = value; }

        public int Purple { get => purple; private set => purple = value; }
        public int Red { get => red; private set => red = value; }
        public int Blue { get => blue; private set => blue = value; }
        public int Green { get => green; private set => green = value; }
        public int Brown { get => brown; private set => brown = value; }
        #endregion

        private void Awake()
        {
            purple = PlayerPrefs.GetInt("Purple", 0);
            red = PlayerPrefs.GetInt("Red", 0);
            blue = PlayerPrefs.GetInt("Blue", 0);
            green = PlayerPrefs.GetInt("Green", 0);
            brown = PlayerPrefs.GetInt("Brown", 0);
            currentCapacity = CalculateCapacity();
        }

        private void Start()
        {
        }

        private void OnDisable()
        {
            onCapacityChanged?.RemoveAllListeners();
        }

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
                    purple += resourceAmount;
                    PlayerPrefs.SetInt("Purple", purple);
                    break;
                case ResourceTypes.Red:
                    red += resourceAmount;
                    PlayerPrefs.SetInt("Red", red);
                    break;
                case ResourceTypes.Blue:
                    blue += resourceAmount;
                    PlayerPrefs.SetInt("Blue", blue);
                    break;
                case ResourceTypes.Green:
                    green += resourceAmount;
                    PlayerPrefs.SetInt("Green", green);
                    break;
                case ResourceTypes.Brown:
                    brown += resourceAmount;
                    PlayerPrefs.SetInt("Brown", brown);
                    break;
            }
            currentCapacity = CalculateCapacity();
            onCapacityChanged?.Invoke();
        }

        public void ResetResources()
        {
            currentCapacity = 0;
            purple = red = blue = green = brown = 0;
            PlayerPrefs.SetInt("Purple", purple);
            PlayerPrefs.SetInt("Red", red);
            PlayerPrefs.SetInt("Blue", blue);
            PlayerPrefs.SetInt("Green", green);
            PlayerPrefs.SetInt("Brown", brown);
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