using SpaceCarrier.Controlls;
using SpaceCarrier.Rewards;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace SpaceCarrier.SpaceShips
{
    public class ShipHealth : MonoBehaviour
    {
        //God Mode for testing
        public bool IDDQD = false;

        [SerializeField] private ParticleSystem dieFX;
        [SerializeField] private GameObject body;

        public IEnumerator Die()
        {
            if (IDDQD) yield break;

            float deathDuration = 2f;
            GetComponent<ShipAudio>().PlayExplosionClip();
            GetComponent<Collider>().enabled = false;
            GetComponent<PlayerController>().DisaleController();
            body.SetActive(false);
            RewardManager.ResetCollectedResources();
            dieFX.gameObject.SetActive(true);
            GetComponent<Harvester>().OnDie();

            yield return new WaitForSeconds(deathDuration);
            SceneManager.LoadScene(0);
        }
    }
}
