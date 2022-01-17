using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceCarrier.Controls;

namespace SpaceCarrier.SpaceShips
{
    [RequireComponent(typeof(InputProvider))]
    public class PlayerController : MonoBehaviour
    {
        InputProvider inputProvider;
        ShipMover shipMover;
        HyperDriver hyperDriver;



        void Awake()
        {
            inputProvider = GetComponent<InputProvider>();
            shipMover = GetComponent<ShipMover>();
            hyperDriver = GetComponent<HyperDriver>();
        }

        void FixedUpdate()
        {
            if (inputProvider.moveDirection == Vector2.zero) return;
            shipMover.MoveShip(new Vector3(inputProvider.moveDirection.x, 0, inputProvider.moveDirection.y));
        }

        private void Update()
        {
            hyperDriver.Hyperjump(inputProvider.isJumping);
        }
    }
}
