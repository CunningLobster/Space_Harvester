using System.Collections;
using UnityEngine;

namespace SpaceCarrier.OrbitalMotion
{
    public class OrbitMotion : MonoBehaviour
    {
        [Range(0, 1f)] public float orbitProgress = 0f;
        public float orbitPeriod = 3f;
        private OrbitPath orbitPath;

        private void Start()
        {
            orbitPath = GetComponent<OrbitPath>();
            SetOrbitingObjectPosition();
            StartCoroutine(AnimateOrbit());
        }

        private void SetOrbitingObjectPosition()
        {
            Vector2 orbitPos = orbitPath.path.Evaluate(orbitProgress);
            transform.localPosition = new Vector3(orbitPos.x, 0, orbitPos.y);
        }

        private IEnumerator AnimateOrbit()
        {
            //Zero protection
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
