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

        private void OnTriggerStay(Collider other)
        {
            if (!other.gameObject.CompareTag("Pullable")) return;

            gravity.PullObject(other);
        }

        private void OnTriggerExit(Collider other)
        {
            gravity.ReleaseObject();
        }
    }
}
