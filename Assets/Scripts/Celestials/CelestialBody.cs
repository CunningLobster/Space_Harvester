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

        private void OnTriggerStay(Collider other)
        {
            if (!other.gameObject.CompareTag("Pullable")) return;
            print("Object is in the gravity field");

            gravity.PullObject(other);
        }
    }
}
