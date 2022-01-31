using SpaceCarrier.HomeSystem;
using SpaceCarrier.Resoures;
using UnityEngine;

namespace SpaceCarrier.TradeStation
{
    public class TradeStationMenu : MonoBehaviour
    {
        [SerializeField] GameObject homeSystemMainMenu;
        [SerializeField] ResourcePanel homeResourcePanel;
        [SerializeField] HomeResources homeResources;

        public void BackToHomeSystemMainMenu()
        {
            homeResourcePanel.UpdatePanel(homeResources.Resources, homeResources.Credits);
            homeSystemMainMenu.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}