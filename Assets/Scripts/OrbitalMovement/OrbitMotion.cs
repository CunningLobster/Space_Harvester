using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceCarrier.Celestials
{
    public class OrbitMotion : MonoBehaviour
    {
        [SerializeField] Transform centralBody = null;
        Orbit orbitToMoveOn;

        [Range(0, 1f)] public float orbitProgress = 0f;
        [SerializeField] float orbitPeriod = 3f;

        private void Start()
        {
            if (centralBody == null)
            {
                return;
            }
            orbitToMoveOn = centralBody.GetComponent<Orbit>();
            SetOrbitingObjectPosition();
            StartCoroutine(AnimateOrbit());
        }

        void SetOrbitingObjectPosition()
        {
            Vector2 orbitPos = orbitToMoveOn.path.Evaluate(orbitProgress);
            transform.localPosition = new Vector3(orbitPos.x, 0, orbitPos.y);
        }

        IEnumerator AnimateOrbit()
        {
            if (orbitPeriod < .1f)
                orbitPeriod = .1f;
            float orbitSpeed = 1f / orbitPeriod;
            while (true)
            {
                orbitProgress += Time.deltaTime * orbitSpeed;
                orbitProgress %= 1f;
                SetOrbitingObjectPosition();
                yield return null;
            }
        }
    }
}
