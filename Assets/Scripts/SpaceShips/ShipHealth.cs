using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceCarrier.SpaceShips
{
    public class ShipHealth : MonoBehaviour
    {
        public bool IDDQD = false;
        [SerializeField] ParticleSystem dieFX;
        [SerializeField] GameObject body;

        public IEnumerator Die()
        {
            if (IDDQD) yield break;

            float deathDuration = 2f;
            GetComponent<PlayerController>().enabled = false;
            body.SetActive(false);
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
