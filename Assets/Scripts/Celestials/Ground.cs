using SpaceCarrier.SpaceShips;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceCarrier.Celestials
{
    public class Ground : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent<ShipHealth>(out ShipHealth sh)) return;
            StartCoroutine(sh.Die());
        }
    }
}