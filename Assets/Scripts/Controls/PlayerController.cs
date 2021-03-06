using SpaceCarrier.Controls;
using SpaceCarrier.SpaceShips;
using UnityEngine;

namespace SpaceCarrier.Controlls
{
    [RequireComponent(typeof(InputProvider))]

    //This class required to perform Ship Controll
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

        private void Update()
        {
            hyperDriver.Hyperjump(inputProvider.isJumping);
            shipMover.MoveShip(new Vector3(inputProvider.moveDirection.x, 0, inputProvider.moveDirection.y));
        }


        //OnWormholeJump, OnDie
        public void DisaleController()
        { 
            GetComponent<PlayerController>().enabled = false;
        }
    }
}
