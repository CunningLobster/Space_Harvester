using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceCarrier.SpaceShips
{
    public class ShipMover : MonoBehaviour
    {
        [SerializeField] float forwardSpeed = 10f;
        [SerializeField] float yawSpeed = 2f;
        [SerializeField] float screenSpaceBorderOffset = .1f;

        Camera mainCamera;
        Rigidbody rb;

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
            rb.AddForce(transform.forward * movingVector.magnitude * forwardSpeed);
            RotateShip(movingVector);
        }

        private void RotateShip(Vector3 movingVector)
        {
            Quaternion targetRotation = Quaternion.Euler(0, Mathf.Atan2(movingVector.x, movingVector.z) * Mathf.Rad2Deg, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, yawSpeed);
        }

        void KeepShipOnScreen()
        {
            Vector3 newPosition = transform.position;
            Vector3 viewPortPosition = mainCamera.WorldToViewportPoint(transform.position);
            Debug.Log(newPosition);

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

    }
}
