using SpaceCarrier.Physics;
using UnityEngine;

namespace SpaceCarrier.SpaceShips
{
    public class ShipMover : ForceInfluencer
    {
        [SerializeField] private float forwardSpeed = 10f;
        [SerializeField] private float yawSpeed = 2f;
        [SerializeField] private float screenSpaceBorderOffset = .1f;
        private Camera mainCamera;
        private Rigidbody rb;

        Vector3 thrust = new Vector3();

        private void Awake()
        {
            mainCamera = Camera.main;
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            KeepShipOnScreen();
        }

        public void MoveShip(Vector3 movingVector)
        {
            rb.angularVelocity = Vector3.zero;
            thrust = transform.forward * movingVector.magnitude * forwardSpeed;

            if (movingVector == Vector3.zero) return;
            RotateShip(movingVector);
        }

        public float GetMaxMovingForceMagnitude()
        {
            Vector3 force = transform.forward * forwardSpeed;
            Debug.Log("Ship Move Force: " + force.magnitude / rb.mass);
            return force.magnitude / rb.mass;
        }

        private void RotateShip(Vector3 movingVector)
        {
            Quaternion targetRotation = Quaternion.Euler(0, Mathf.Atan2(movingVector.x, movingVector.z) * Mathf.Rad2Deg, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, yawSpeed);
        }

        private void KeepShipOnScreen()
        {
            Vector3 newPosition = transform.position;
            Vector3 viewPortPosition = mainCamera.WorldToViewportPoint(transform.position);

            if (viewPortPosition.x > 1)
            {
                newPosition.x = -newPosition.x + screenSpaceBorderOffset;
            }
            else if (viewPortPosition.x < 0)
            {
                newPosition.x = -newPosition.x - screenSpaceBorderOffset;
            }
            else if (viewPortPosition.y > 1)
            {
                newPosition.z = -newPosition.z + screenSpaceBorderOffset;
            }
            else if (viewPortPosition.y < 0)
            {
                newPosition.z = -newPosition.z - screenSpaceBorderOffset;
            }

            transform.position = newPosition;
        }

        public override Vector3 GetForce()
        {
            return thrust;
        }
    }
}
