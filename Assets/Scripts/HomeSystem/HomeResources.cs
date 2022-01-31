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

        int credits;
        Dictionary<ResourceTypes, int> resources = new Dictionary<ResourceTypes, int>();

        #region RESOURCE_KEYS
        string creditsKey = "Credits_Key";
        string h_purpleKey = "H_Purple_Key";
        string h_redKey = "H_Red_Key";
        string h_blueKey = "H_Blue_Key";
        string h_greenKey = "H_Green_Key";
        string h_brownKey = "H_Brown_Key";
        #endregion

        #region PROPERTIES
        public int Credits { get => credits; set => credits = value; }
        public string CreditsKey { get => creditsKey; }
        public string H_purpleKey { get => h_purpleKey; }
        public string H_redKey { get => h_redKey; }
        public string H_blueKey { get => h_blueKey; }
        public string H_greenKey { get => h_greenKey; }
        public string H_brownKey { get => h_brownKey; }


        public Dictionary<ResourceTypes, int> Resources { get => resources; private set => resources = value; }
        #endregion

        private void Start()
        {
            DefineResourceValues();
            SetResourceValue(ResourceTypes.Purple, shipCargo.CargoResources[ResourceTypes.Purple], h_purpleKey);
            SetResourceValue(ResourceTypes.Red, shipCargo.CargoResources[ResourceTypes.Red], h_redKey);
            SetResourceValue(ResourceTypes.Blue, shipCargo.CargoResources[ResourceTypes.Blue], h_blueKey);
            SetResourceValue(ResourceTypes.Green, shipCargo.CargoResources[ResourceTypes.Green], h_greenKey);
            SetResourceValue(ResourceTypes.Brown, shipCargo.CargoResources[ResourceTypes.Brown], h_brownKey);

            shipCargo.ResetResources();
        }

        private void DefineResourceValues()
        {
            credits = PlayerPrefs.GetInt(creditsKey, 0);
            resources[ResourceTypes.Purple] = PlayerPrefs.GetInt(h_purpleKey, 0);
            resources[ResourceTypes.Red] = PlayerPrefs.GetInt(h_redKey, 0);
            resources[ResourceTypes.Blue] = PlayerPrefs.GetInt(h_blueKey, 0);
            resources[ResourceTypes.Green] = PlayerPrefs.GetInt(h_greenKey, 0);
            resources[ResourceTypes.Brown] = PlayerPrefs.GetInt(h_brownKey, 0);
        }

        public void SetResourceValue(ResourceTypes type, int newValue, string valueKey)
        {
            resources[type] += newValue;
            PlayerPrefs.SetInt(valueKey, resources[type]);
            homeResourcePanel.UpdatePanel(resources, credits);
        }

        private void ResetResources()
        {
            credits = 0;
            foreach (var key in resources.Keys.ToList())
            {
                resources[key] = 0;
            }
            PlayerPrefs.SetInt(creditsKey, credits);
            PlayerPrefs.SetInt(h_purpleKey, resources[ResourceTypes.Purple]);
            PlayerPrefs.SetInt(h_redKey, resources[ResourceTypes.Red]);
            PlayerPrefs.SetInt(h_blueKey, resources[ResourceTypes.Blue]);
            PlayerPrefs.SetInt(h_greenKey, resources[ResourceTypes.Green]);
            PlayerPrefs.SetInt(h_brownKey, resources[ResourceTypes.Brown]);
            homeResourcePanel.UpdatePanel(resources, credits);
        }


#if UNITY_EDITOR
        private void Update()
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
                ResetResources();

            //Debug.Log(PlayerPrefs.GetInt(h_purpleKey, 0));
            //Debug.Log(PlayerPrefs.GetInt(h_redKey, 0));
            //Debug.Log(PlayerPrefs.GetInt(h_blueKey, 0));
            //Debug.Log(PlayerPrefs.GetInt(h_greenKey, 0));
            //Debug.Log(PlayerPrefs.GetInt(h_brownKey, 0));
        }
#endif
    }
}
