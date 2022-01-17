using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceCarrier.SpaceShips
{
    public class ShipMover : MonoBehaviour
    {
        [SerializeField] float forwardSpeed = 10f;
        [SerializeField] float yawSpeed = 2f;

        Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
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

    }
}
