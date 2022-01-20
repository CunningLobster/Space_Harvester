using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SpaceCarrier.Celestials
{
    public class ResourceDisplayer : MonoBehaviour
    {
        TMP_Text valueText;
        int value;

        private void Awake()
        {
            valueText = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            valueText.text = value.ToString();
        }

        public void SetValue(int newValue)
        {
            value = newValue;
        }
        public int GetValue()
        {
            return value;
        }
    }
}
