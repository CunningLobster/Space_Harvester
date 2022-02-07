using SpaceCarrier.Prefs;
using SpaceCarrier.Resoures;
using SpaceCarrier.SpaceShips;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceCarrier.HomeSystem
{
    //This class contains all operations with resources in the Home System
    public class HomeResources : MonoBehaviour
    {
        //Interracts with shipCargo
        [SerializeField] Cargo shipCargo;
        [SerializeField] ResourcePanel homeResourcePanel;

        //Values of credits and planet Resources
        private int credits;
        Dictionary<ResourceTypes, int> resources = new Dictionary<ResourceTypes, int>();

        #region PROPERTIES
        public int Credits { get => credits; set => credits = value; }

        public Dictionary<ResourceTypes, int> Resources { get => resources; private set => resources = value; }
        #endregion

        private void Start()
        {
            //Peek home resource values and credits directly from playerPrefs
            DefineResourceValues();

            //Load resources from ship cargo
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

        //Set all home resources to 0. It's used only in edit mode
        private void ResetResources()
        {
            credits = 0;
            foreach (var key in resources.Keys.ToList())
            {
                PlayerPrefs.SetInt(PrefsKeys.homeResourcesKeys[key], 0);
                resources[key] = PlayerPrefs.GetInt(PrefsKeys.homeResourcesKeys[key], 0);
            }
            PlayerPrefs.SetInt(PrefsKeys.creditsKey, credits);
            homeResourcePanel.UpdatePanel(resources, credits);
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
