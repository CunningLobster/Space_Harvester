using SpaceCarrier.SpaceShips;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceCarrier.HomeSystem
{
    public class HomeResources : MonoBehaviour
    {
        [SerializeField] Cargo shipCargo;
        [SerializeField] HomeResourcePanel homeResourcePanel;

        [SerializeField]private int credits;
        [SerializeField]private int purple;
        [SerializeField]private int red;
        [SerializeField]private int blue;
        [SerializeField]private int green;
        [SerializeField]private int brown;

        #region RESOURCE_KEYS
        string h_creditsKey = "H_Credits_Key";
        string h_purpleKey = "H_Purple_Key";
        string h_redKey = "H_Red_Key";
        string h_blueKey = "H_Blue_Key";
        string h_greenKey = "H_Green_Key";
        string h_brownKey = "H_Brown_Key";
        #endregion

        #region PROPERTIES
        public int Credits { get => credits; private set { credits = value; } }
        public int Purple { get => purple; private set { purple = value; } }
        public int Red { get => red; private set { red = value; } }
        public int Blue { get => blue; private set { blue = value; } }
        public int Green { get => green; private set { green = value; } }
        public int Brown { get => brown; private set { brown = value; } }
        #endregion

        private void Start()
        {
            DefineResourceValues();
            SetResourceValue(ref purple, shipCargo.Purple, h_purpleKey);
            SetResourceValue(ref red, shipCargo.Red, h_redKey);
            SetResourceValue(ref blue, shipCargo.Blue, h_blueKey);
            SetResourceValue(ref green, shipCargo.Green, h_greenKey);
            SetResourceValue(ref brown, shipCargo.Brown, h_brownKey);

            shipCargo.ResetResources();
        }

        private void DefineResourceValues()
        {
            purple = PlayerPrefs.GetInt(h_purpleKey, 0);
            red = PlayerPrefs.GetInt(h_redKey, 0);
            blue = PlayerPrefs.GetInt(h_blueKey, 0);
            green = PlayerPrefs.GetInt(h_greenKey, 0);
            brown = PlayerPrefs.GetInt(h_brownKey, 0);
        }

        private void SetResourceValue(ref int h_value, int s_value, string valueKey)
        {
            h_value += s_value;
            Debug.Log("Home Value: " + h_value);
            PlayerPrefs.SetInt(valueKey, h_value);
            homeResourcePanel.UpdatePanel(credits, purple, red, blue, green, brown);
        }

        private void ResetResources()
        {
            credits = purple = red = blue = green = brown = 0;
            PlayerPrefs.SetInt(h_purpleKey, purple);
            PlayerPrefs.SetInt(h_redKey, red);
            PlayerPrefs.SetInt(h_blueKey, blue);
            PlayerPrefs.SetInt(h_greenKey, green);
            PlayerPrefs.SetInt(h_brownKey, brown);
            homeResourcePanel.UpdatePanel(credits, purple, red, blue, green, brown);
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
