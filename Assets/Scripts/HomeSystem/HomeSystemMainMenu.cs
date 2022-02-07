using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceCarrier.HomeSystem
{
    public class HomeSystemMainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject tradeStationMenu;
        [SerializeField] private GameObject shipyardMenu;
        public void OpenTradeStationMenu()
        {
            tradeStationMenu.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OpenShipyardMenu()
        {
            shipyardMenu.SetActive(true);
            gameObject.SetActive(false);
        }

        public void LeaveHomeSystem()
        {
            SceneManager.LoadScene(1);
        }
    }

}
