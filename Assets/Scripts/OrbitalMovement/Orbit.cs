using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceCarrier.Celestials
{
    [RequireComponent(typeof(LineRenderer))]
    public class Orbit : MonoBehaviour
    {
        LineRenderer lr;
        [Range(3, 36)] public int segments;
        public Ellipse path;

        private void Awake()
        {
            lr = GetComponent<LineRenderer>();
        }

        private void CalculateOrbitPath()
        {
            Vector3[] points = new Vector3[segments + 1];
            for (int i = 0; i < segments; i++)
            {
                Vector2 position2D = path.Evaluate((float)i / (float)segments);
                points[i] = new Vector3(position2D.x, 0f, position2D.y) + transform.position;
            }
            points[segments] = points[0];

            lr.positionCount = segments + 1;
            lr.SetPositions(points);
        }

        private void Update()
        {
            CalculateOrbitPath();
        }

        private void OnValidate()
        {
            lr = GetComponent<LineRenderer>();
            CalculateOrbitPath();
        }
    }
}
