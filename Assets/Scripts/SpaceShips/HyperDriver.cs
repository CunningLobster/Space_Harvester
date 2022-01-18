using SpaceCarrier.Wormholes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceCarrier.SpaceShips
{
    public class HyperDriver : MonoBehaviour
    {
        Wormhole wormhole;
        [SerializeField] float preparationTime = 3f;
        float timeToJump = 0;

        Collider shipCollider;

        private void Awake()
        {
            shipCollider = GetComponent<Collider>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (!other.TryGetComponent<Wormhole>(out Wormhole wormhole)) return;
            this.wormhole = wormhole;
        }

        private void OnTriggerExit(Collider other)
        {
            this.wormhole = null;
        }

        public void Hyperjump(bool jumpStarted)
        {
            if (!jumpStarted || wormhole == null)
            {
                timeToJump = 0;
                return;
            }

            wormhole.Gravity.PullObject(shipCollider);

            timeToJump += Time.deltaTime;
            print(timeToJump);
            if(timeToJump >= preparationTime)
                wormhole.PullShip();
        }
    }
}