using UnityEngine;
using SpaceCarrier.SpaceShips;
using UnityEngine.InputSystem;

namespace SpaceCarrier.Physics
{
    public class Gravity : ForceInfluencer
    {
        [SerializeField] private float g = 0.667f;
        [SerializeField] private SphereCollider gravityField;
        [SerializeField] private float easing = 1f;

        Rigidbody rb;
        ShipMover shipMover;
        [SerializeField] private float dangerRadius;
        private float shipMass;
        private float mass;

        Vector3 force = new Vector3();

        private void Awake()
        {
            shipMover = FindObjectOfType<ShipMover>();
            shipMass = shipMover.GetComponent<Rigidbody>().mass;

            rb = GetComponent<Rigidbody>();
            mass = rb.mass;
        }

        private void Start()
        {
            shipMover.GetMaxMovingForceMagnitude();
            DefineDangerZone();
        }

        public void PullObject(Collider other)
        {
            Rigidbody otherRb = other.GetComponent<Rigidbody>();

            Vector3 direction = rb.position - otherRb.position;
            float sqrDistance = direction.sqrMagnitude;
            sqrDistance = Mathf.Max(sqrDistance, easing);

            float forceMagnitude = g * mass * otherRb.mass / sqrDistance;
            force = direction * forceMagnitude;
            Debug.Log(direction.magnitude);
        }

        public void ReleaseObject()
        {
            force = Vector3.zero;
        }

        public void DefineDangerZone()
        {
            print("DD Defined");
            dangerRadius = g * shipMass * mass / shipMover.GetMaxMovingForceMagnitude();
        }

        private void Update()
        {
            if (Keyboard.current.fKey.wasPressedThisFrame)
            { DefineDangerZone(); }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, gravityField.radius * transform.lossyScale.x);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, dangerRadius * transform.lossyScale.x);
        }

        public override Vector3 GetForce()
        {
            return force;
        }
    }
}
