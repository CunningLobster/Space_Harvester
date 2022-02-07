using SpaceCarrier.Physics;
using SpaceCarrier.Rewards;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace SpaceCarrier.Wormholes
{
    public class Wormhole : MonoBehaviour
    {
        [SerializeField] private bool isHome;
        public Gravity Gravity { get; private set; }
        [SerializeField] UnityEvent onWormholeJump;

        private void Awake()
        {
            Gravity = GetComponent<Gravity>();
        }

        public IEnumerator PullShip()
        {
            onWormholeJump?.Invoke();
            yield return new WaitForSeconds(1f);

            if (!isHome)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                RewardManager.ResetCollectedResources();
                SceneManager.LoadScene("Home_System");
            }
        }
    }
}
