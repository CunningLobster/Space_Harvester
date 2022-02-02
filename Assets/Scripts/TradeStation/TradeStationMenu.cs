using SpaceCarrier.HomeSystem;
using SpaceCarrier.Resoures;
using UnityEngine;

namespace SpaceCarrier.TradeStation
{
    public class TradeStationMenu : MonoBehaviour
    {
        [SerializeField] GameObject homeSystemMainMenu;
        [SerializeField] TradeZone tradeZone;

        public void BackToHomeSystemMainMenu()
        {
            tradeZone.OnBack();
            homeSystemMainMenu.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}