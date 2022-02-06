using SpaceCarrier.Physics;
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
            if (!isHome)
            {
                onWormholeJump?.Invoke();
                yield return new WaitForSeconds(1f);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
            else
            {
                onWormholeJump?.Invoke();
                yield return new WaitForSeconds(1f);
                SceneManager.LoadScene("Home_System");
            }
        }
    }
}
