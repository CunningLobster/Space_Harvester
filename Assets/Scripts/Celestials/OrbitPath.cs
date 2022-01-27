using UnityEngine;

namespace SpaceCarrier.Celestials
{
    [RequireComponent(typeof(LineRenderer))]
    public class OrbitPath : MonoBehaviour
    {
        private LineRenderer lr;
        private int segments = 36;

        public Ellipse path;
        private Transform centralBody = null;

        private void Awake()
        {
            centralBody = transform.parent;
            lr = GetComponent<LineRenderer>();
        }

        private void CalculateOrbitPath()
        {
            lr.enabled = true;

            Vector3[] points = new Vector3[segments + 1];
            for (int i = 0; i < segments; i++)
            {
                Vector2 position2D = path.Evaluate((float)i / (float)segments);
                points[i] = new Vector3(position2D.x, 0f, position2D.y) + transform.parent.position;
            }
            points[segments] = points[0];

            lr.positionCount = segments + 1;
            lr.SetPositions(points);
        }

        private void Update()
        {
            if (centralBody == null) return;
            CalculateOrbitPath();
        }

        private void OnValidate()
        {
            centralBody = transform.parent;
            lr = GetComponent<LineRenderer>();
            if (centralBody == null) return;
            CalculateOrbitPath();
        }
    }
}
