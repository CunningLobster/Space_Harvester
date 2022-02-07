using SpaceCarrier.OrbitalMotion;
using SpaceCarrier.Physics;
using UnityEngine;


namespace SpaceCarrier.Celestials
{
    [RequireComponent(typeof(OrbitPath), typeof(OrbitMotion))]
    public class CelestialBody : MonoBehaviour
    {
        private Gravity gravity;

        private void Awake()
        {
            gravity = GetComponent<Gravity>();
        }

        //Calculating force to attach it to a Pullable obj
        private void OnTriggerStay(Collider other)
        {
            if (!other.gameObject.CompareTag("Pullable")) return;

            gravity.CalculateGravityForce(other);
        }

        //Remove gravity force if obj is out of gravity field
        private void OnTriggerExit(Collider other)
        {
            gravity.ReleaseObject();
        }
    }
}
