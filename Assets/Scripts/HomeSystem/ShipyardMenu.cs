using SpaceCarrier.Shipyard;
using UnityEngine;

namespace SpaceCarrier.HomeSystem
{
    public class ShipyardMenu : MonoBehaviour
    {
        [SerializeField] GameObject homeSystemMainMenu;
        [SerializeField] ShipyardStats shipyardStats;

        public void BackToHomeSystemMainMenu()
        {
            shipyardStats.OnReset();
            homeSystemMainMenu.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}