using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceCarrier.Controls;

namespace SpaceCarrier.SpaceShips
{
    public class PlayerController : MonoBehaviour
    {
        InputProvider inputProvider;
        ShipMover shipMover;

        void Awake()
        {
            inputProvider = GetComponent<InputProvider>();
            shipMover = GetComponent<ShipMover>();
        }

        void FixedUpdate()
        {
            if (inputProvider.moveDirection == Vector2.zero) return;
            shipMover.MoveShip(new Vector3(inputProvider.moveDirection.x, 0, inputProvider.moveDirection.y));
        }
    }
}
