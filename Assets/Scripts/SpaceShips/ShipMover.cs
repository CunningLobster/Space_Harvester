using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceCarrier.Controls;

namespace SpaceCarrier.SpaceShips
{
    public class ShipMover : MonoBehaviour
    {
        [SerializeField] float speed = 10f;
        Rigidbody rb;
        InputProvider inputProvider;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            inputProvider = GetComponent<InputProvider>();
        }

        private void FixedUpdate()
        {
            rb.angularVelocity = Vector3.zero;
            rb.velocity = new Vector3(inputProvider.moveDirection.x, 0, inputProvider.moveDirection.y) * speed;
            if (inputProvider.moveDirection != Vector2.zero)
            {
                transform.rotation = Quaternion.Euler(0, Mathf.Atan2(inputProvider.moveDirection.x, inputProvider.moveDirection.y) / Mathf.PI * 180, 0);
            }
        }
    }
}
