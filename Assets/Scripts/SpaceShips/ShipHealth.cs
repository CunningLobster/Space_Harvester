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
        public bool IDDQD = false;
        [SerializeField] private ParticleSystem dieFX;
        [SerializeField] private GameObject body;

        public IEnumerator Die()
        {
            if (IDDQD) yield break;

            float deathDuration = 2f;
            GetComponent<ShipAudio>().PlayExplosionAudioEffect();
            GetComponent<Collider>().enabled = false;
            GetComponent<PlayerController>().DisaleController();
            body.SetActive(false);
            RewardManager.ResetCollectedResources();
            dieFX.gameObject.SetActive(true);

            if (TryGetComponent<Harvester>(out Harvester harvester))
            {
                harvester.OnDie();
            }

            yield return new WaitForSeconds(deathDuration);
            SceneManager.LoadScene(0);
        }
    }
}
