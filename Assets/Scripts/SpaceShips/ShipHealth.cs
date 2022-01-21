using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceCarrier.SpaceShips
{
    public class ShipHealth : MonoBehaviour
    {
        [SerializeField] float maxHP = 100f;
        public bool IDDQD = false;
        [SerializeField] ParticleSystem dieFX;
        [SerializeField] GameObject body;

        public IEnumerable Die()
        {
            if (IDDQD) yield break;

            float deathDuration = 2f;
            GetComponent<PlayerController>().enabled = false;
            body.SetActive(false);
            dieFX.gameObject.SetActive(true);

            if (TryGetComponent<Harvester>(out Harvester harvester))
            {
                harvester.Cargo.ResetResources();
                harvester.enabled = false;
            }

            yield return new WaitForSeconds(deathDuration);
            SceneManager.LoadScene(0);
        }
    }
}
