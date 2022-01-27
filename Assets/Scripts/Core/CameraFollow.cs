using UnityEngine;

namespace SpaceCarrier.Core
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        private Vector3 offset;

        private void Awake()
        {
            offset = target.position - transform.position;
        }

        private void Update()
        {
            transform.position = new Vector3(target.position.x, transform.position.y, target.position.z - offset.z);
        }
    }
}
