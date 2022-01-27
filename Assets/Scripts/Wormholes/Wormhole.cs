using SpaceCarrier.Physics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceCarrier.Wormholes
{
    public class Wormhole : MonoBehaviour
    {
        [SerializeField] private bool isHome;
        public Gravity Gravity { get; private set; }

        private void Awake()
        {
            Gravity = GetComponent<Gravity>();
        }

        public void PullShip()
        {
            if (!isHome)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                SceneManager.LoadScene("Home_System");
            }
        }
    }
}
