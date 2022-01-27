using TMPro;
using UnityEngine;

namespace SpaceCarrier.Celestials
{
    public class ResourceDisplayer : MonoBehaviour
    {
        private TMP_Text valueText;
        private int value;

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
