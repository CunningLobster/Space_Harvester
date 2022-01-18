using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceCarrier.Physics
{
    public class Gravity : MonoBehaviour
    {
        [SerializeField] float g = 0.667f;
        [SerializeField] SphereCollider gravityField;
        [SerializeField] float easing = 1f;

        public void PullObject(Collider other)
        {
            print("Object is in the gravity field");

            Rigidbody rb = GetComponent<Rigidbody>();
            Rigidbody otherRb = other.GetComponent<Rigidbody>();

            Vector3 direction = rb.position - otherRb.position;
            float sqrDistance = direction.sqrMagnitude;
            sqrDistance = Mathf.Max(sqrDistance, easing);

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
