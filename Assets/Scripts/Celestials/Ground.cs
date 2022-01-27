using SpaceCarrier.SpaceShips;
using UnityEngine;

namespace SpaceCarrier.Celestials
{
    public class Ground : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent<ShipHealth>(out ShipHealth sh)) return;
            StartCoroutine(sh.Die());
        }
    }
}