using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceCarrier.Celestials
{
    public class CelestialBody : MonoBehaviour
    {
        public float G = 0.667f;

        private void OnTriggerStay(Collider other)
        {
            print("Object is in the gravity field");

            Rigidbody rb = GetComponent<Rigidbody>();
            Rigidbody otherRb = other.GetComponent<Rigidbody>();

            Vector3 direction = rb.position - otherRb.position;
            float sqrDistance = direction.sqrMagnitude;

            float forceMagnitude = G * rb.mass * otherRb.mass / sqrDistance;
            Vector3 force = direction * forceMagnitude;

            otherRb.AddForce(force);
        }
    }
}
