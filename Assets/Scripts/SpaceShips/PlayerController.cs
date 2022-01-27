using SpaceCarrier.Controls;
using UnityEngine;

namespace SpaceCarrier.SpaceShips
{
    [RequireComponent(typeof(InputProvider))]
    public class PlayerController : MonoBehaviour
    {
        private InputProvider inputProvider;
        private ShipMover shipMover;
        private HyperDriver hyperDriver;

        private void Awake()
        {
            inputProvider = GetComponent<InputProvider>();
            shipMover = GetComponent<ShipMover>();
            hyperDriver = GetComponent<HyperDriver>();
        }

        private void FixedUpdate()
        {
            hyperDriver.Hyperjump(inputProvider.isJumping);

            if (inputProvider.moveDirection == Vector2.zero) return;
            shipMover.MoveShip(new Vector3(inputProvider.moveDirection.x, 0, inputProvider.moveDirection.y));
        }
    }
}
