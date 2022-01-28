using UnityEngine;

namespace SpaceCarrier.Physics
{
    public abstract class ForceInfluencer : MonoBehaviour
    {
        public abstract Vector3 GetForce();
    }
}