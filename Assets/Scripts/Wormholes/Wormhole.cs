using SpaceCarrier.Physics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace SpaceCarrier.Wormholes
{
    public class Wormhole : MonoBehaviour
    {
        [SerializeField] private bool isHome;
        public Gravity Gravity { get; private set; }
        [SerializeField] UnityEvent onRightWormholeJump;

        private void Awake()
        {
            Gravity = GetComponent<Gravity>();
        }

        public void PullShip()
        {
            if (!isHome)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                onRightWormholeJump?.Invoke();
            }
            else
            {
                SceneManager.LoadScene("Home_System");
            }
        }

        private void OnDisable()
        {
            onRightWormholeJump.RemoveAllListeners();
        }
    }
}
