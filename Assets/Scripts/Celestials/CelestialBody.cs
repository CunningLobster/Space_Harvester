using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceCarrier.Celestials
{
    [RequireComponent(typeof(OrbitPath), typeof(OrbitMotion))]
    public class CelestialBody : MonoBehaviour
    {
        [SerializeField] float g = 0.667f;
        [SerializeField] SphereCollider gravityField;

        private void OnTriggerStay(Collider other)
        {
            if (!other.gameObject.CompareTag("Pullable")) return;

            PullObject(other);
        }

        private void PullObject(Collider other)
        {
            print("Object is in the gravity field");

            Rigidbody rb = GetComponent<Rigidbody>();
            Rigidbody otherRb = other.GetComponent<Rigidbody>();

            Vector3 direction = rb.position - otherRb.position;
            float sqrDistance = direction.sqrMagnitude;

            float forceMagnitude = g * rb.mass * otherRb.mass / sqrDistance;
            Vector3 force = direction * forceMagnitude;

            otherRb.AddForce(force);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, gravityField.radius * transform.lossyScale.x);
        }
    }
}
