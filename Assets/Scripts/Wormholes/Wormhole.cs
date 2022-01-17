using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceCarrier.Wormholes
{
    public class Wormhole : MonoBehaviour
    {
        [SerializeField] bool isHome;

        public void PullShip()
        {
            if (!isHome)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else 
            {
                SceneManager.LoadScene("Home_System");
            }
        }
    }
}
