using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceCarrier.Celestials
{
    [RequireComponent(typeof(LineRenderer))]
    public class OrbitPath : MonoBehaviour
    {
        LineRenderer lr;
        [Range(3, 36)] public int segments;
        public Ellipse path;
        Transform centralBody = null;

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
            if(centralBody != null)
                CalculateOrbitPath();
        }

        private void OnValidate()
        {
            lr = GetComponent<LineRenderer>();
            if (centralBody != null)
                CalculateOrbitPath();
        }
    }
}
