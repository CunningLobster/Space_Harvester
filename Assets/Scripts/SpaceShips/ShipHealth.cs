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

        //public IEnumerator Die()
        //{
        //    if (IDDQD) return null;

        //    dieFX.gameObject.SetActive(true);

        //    GetComponent<Harvester>()?.Cargo.ResetResources();
        //    body.SetActive(false);
        //    yield return new WaitForSeconds(dieFX.duration);
        //    Destroy(gameObject);
        //}
    }
}
