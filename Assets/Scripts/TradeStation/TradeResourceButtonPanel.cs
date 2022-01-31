using SpaceCarrier.Resoures;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceCarrier.TradeStation
{
    public class TradeResourceButtonPanel : MonoBehaviour
    {
        [SerializeField] Button purpleButton;
        [SerializeField] Button redButton;
        [SerializeField] Button blueButton;
        [SerializeField] Button greenButton;
        [SerializeField] Button brownButton;

        [SerializeField] TradeZone tradeZone;

        private void Start()
        {
            purpleButton.onClick.AddListener(delegate { tradeZone.OnSelectResource(ResourceTypes.Purple); });
            redButton.onClick.AddListener(delegate { tradeZone.OnSelectResource(ResourceTypes.Red); });
            blueButton.onClick.AddListener(delegate { tradeZone.OnSelectResource(ResourceTypes.Blue); });
            greenButton.onClick.AddListener(delegate { tradeZone.OnSelectResource(ResourceTypes.Green); });
            brownButton.onClick.AddListener(delegate { tradeZone.OnSelectResource(ResourceTypes.Brown); });
        }
    }
}