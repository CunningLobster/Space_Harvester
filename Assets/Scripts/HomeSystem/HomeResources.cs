using SpaceCarrier.Prefs;
using SpaceCarrier.Resoures;
using SpaceCarrier.SpaceShips;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceCarrier.HomeSystem
{
    public class HomeResources : MonoBehaviour
    {
        [SerializeField] Cargo shipCargo;
        [SerializeField] ResourcePanel homeResourcePanel;

        private int credits;
        Dictionary<ResourceTypes, int> resources = new Dictionary<ResourceTypes, int>();


        #region PROPERTIES
        public int Credits { get => credits; set => credits = value; }

        public Dictionary<ResourceTypes, int> Resources { get => resources; private set => resources = value; }
        #endregion

        private void Start()
        {
            DefineResourceValues();
            foreach (var key in resources.Keys.ToList())
            {
                SetResourceValue(key, shipCargo.CargoResources[key]);
            }
            homeResourcePanel.UpdatePanel(resources, credits);
            shipCargo.ResetResources();
        }

        private void DefineResourceValues()
        {
            credits = PlayerPrefs.GetInt(PrefsKeys.creditsKey, 0);
            foreach (var key in PrefsKeys.homeResourcesKeys.Keys.ToList())
            {
                resources[key] = PlayerPrefs.GetInt(PrefsKeys.homeResourcesKeys[key], 0);
            }
        }

        public void SetResourceValue(ResourceTypes type, int newValue)
        {
            resources[type] += newValue;
            PlayerPrefs.SetInt(PrefsKeys.homeResourcesKeys[type], resources[type]);
        }

        private void ResetResources()
        {
            credits = 0;
            foreach (var key in resources.Keys.ToList())
            {
                PlayerPrefs.SetInt(PrefsKeys.homeResourcesKeys[key], resources[key]);
            }
            PlayerPrefs.SetInt(PrefsKeys.creditsKey, credits);
            homeResourcePanel.UpdatePanel(resources, credits);
        }


#if UNITY_EDITOR
        private void Update()
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
                ResetResources();

            //Debug.Log(PlayerPrefs.GetInt(PrefsKeys.homeResourcesKeys[ResourceTypes.Purple], 0));
            //Debug.Log(PlayerPrefs.GetInt(PrefsKeys.homeResourcesKeys[ResourceTypes.Red], 0));
            //Debug.Log(PlayerPrefs.GetInt(PrefsKeys.homeResourcesKeys[ResourceTypes.Blue], 0));
            //Debug.Log(PlayerPrefs.GetInt(PrefsKeys.homeResourcesKeys[ResourceTypes.Green], 0));
            //Debug.Log(PlayerPrefs.GetInt(PrefsKeys.homeResourcesKeys[ResourceTypes.Brown], 0));
        }
#endif
    }
}
