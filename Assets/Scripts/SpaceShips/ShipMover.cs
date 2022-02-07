using SpaceCarrier.Physics;
using SpaceCarrier.ShipStats;
using UnityEngine;

namespace SpaceCarrier.SpaceShips
{
    public class ShipMover : ForceInfluencer
    {
        private Rigidbody rb;

        //Moving parameters
        private float forwardSpeed;
        private float yawSpeed;
        Vector3 movingResultVector = new Vector3();

        //Moving Stats
        [SerializeField] private ShipStat engine;
        [SerializeField] private ShipStat maneurability;

        //Parametrs required for keeping the ship on screen
        [SerializeField] private float screenSpaceBorderOffset = .1f;
        private Camera mainCamera;

        private ShipAudio shipAudio;

        private void Awake()
        {
            forwardSpeed = engine.GetCurrentValue();
            yawSpeed = maneurability.GetCurrentValue();

            mainCamera = Camera.main;
            rb = GetComponent<Rigidbody>();

            shipAudio = GetComponent<ShipAudio>();
        }

        private void Update()
        {
            KeepShipOnScreen();
        }

        public void MoveShip(Vector3 movingVector)
        {
            shipAudio.PlayThrustAudioEffect(movingVector);

            rb.angularVelocity = Vector3.zero;
            movingResultVector = transform.forward * movingVector.magnitude * forwardSpeed;

            if (movingVector == Vector3.zero) return;
            RotateShip(movingVector);
        }

        private void RotateShip(Vector3 movingVector)
        {
            float yawAngleRad = Mathf.Atan2(movingVector.x, movingVector.z);
            float yawAngleDeg = yawAngleRad * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, yawAngleDeg, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, yawSpeed * Time.deltaTime);
        }

        //When ship goes out of screen it appears at another side
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
            return movingResultVector;
        }
    }
}
