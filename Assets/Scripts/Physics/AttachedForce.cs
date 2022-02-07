using UnityEngine;

namespace SpaceCarrier.Physics
{
    //The class respresents attached sum of all forces which influence to the ship
    public class AttachedForce : MonoBehaviour
    {
        Vector3 force = new Vector3();
        Rigidbody rb;
        ForceInfluencer[] forceInfluencers;

        public Vector3 Force { get => force; }
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            forceInfluencers = FindObjectsOfType<ForceInfluencer>();
        }

        //All fixed update is here
        private void FixedUpdate()
        {
            force = GetResultForce();
            rb.AddForce(force);
        }

        Vector3 GetResultForce()
        {
            Vector3 result = new Vector3();
            foreach (var influencer in forceInfluencers)
            {
                result += influencer.GetForce();
            }
            return result;
        }
    }
}