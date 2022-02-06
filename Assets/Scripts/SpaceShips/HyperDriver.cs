using SpaceCarrier.UI;
using SpaceCarrier.Wormholes;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceCarrier.SpaceShips
{
    public class HyperDriver : MonoBehaviour
    {
        private Wormhole wormhole;
        [SerializeField] private float preparationTime = 3f;
        private float timeToJump = 0;
        private Collider shipCollider;

        [SerializeField] private UILogDisplayer logDisplayer;

        private ShipAudio shipAudio;

        private void Awake()
        {
            shipCollider = GetComponent<Collider>();
            shipAudio = GetComponent<ShipAudio>();
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
                wormhole?.Gravity.ReleaseObject();
                timeToJump = 0;
                shipAudio.PlayHyperJumpChargingClip(jumpStarted);
                logDisplayer.ClearLog();
                return;
            }

            shipAudio.PlayHyperJumpChargingClip(jumpStarted);

            wormhole.Gravity.CalculateGravityForce(shipCollider);

            logDisplayer.ShowHyperJumpLog(Mathf.FloorToInt(preparationTime - timeToJump));
            timeToJump += Time.deltaTime;
            if (timeToJump >= preparationTime)
                wormhole.PullShip();
        }
    }
}