using SpaceCarrier.Physics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceCarrier.Celestials
{
    [RequireComponent(typeof(OrbitPath), typeof(OrbitMotion))]
    public class CelestialBody : MonoBehaviour
    {
        Gravity gravity;

        private void Awake()
        {
            gravity = GetComponent<Gravity>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (!other.gameObject.CompareTag("Pullable")) return;

            gravity.PullObject(other);
        }
    }
}
