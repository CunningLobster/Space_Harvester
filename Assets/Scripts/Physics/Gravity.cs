using UnityEngine;

namespace SpaceCarrier.Physics
{
    public class Gravity : ForceInfluencer
    {
        [SerializeField] private float g = 0.667f;
        [SerializeField] private SphereCollider gravityField;

        //Easing is used to avoid deviding by close to zero values
        [SerializeField] private float easing = 1f;

        Rigidbody rb;
        private float mass;

        Vector3 force = new Vector3();

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            mass = rb.mass;
        }

        //Calculating force according Gravity Foece formula
        public void CalculateGravityForce(Collider other)
        {
            Rigidbody otherRb = other.GetComponent<Rigidbody>();

            Vector3 direction = rb.position - otherRb.position;
            float sqrDistance = direction.sqrMagnitude;
            sqrDistance = Mathf.Max(sqrDistance, easing);

            float forceMagnitude = g * mass * otherRb.mass / sqrDistance;
            force = direction * forceMagnitude;
        }

        public void ReleaseObject()
        {
            force = Vector3.zero;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, gravityField.radius * transform.lossyScale.x);
        }

        public override Vector3 GetForce()
        {
            return force;
        }
    }
}
