using UnityEngine;

namespace SpaceCarrier.TradeStation
{
    public class TradeStationMenu : MonoBehaviour
    {
        [SerializeField] GameObject homeSystemMainMenu;

        public void BackToHomeSystemMainMenu()
        {
            homeSystemMainMenu.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}