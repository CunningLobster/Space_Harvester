using UnityEngine;

namespace SpaceCarrier.OrbitalMotion
{
    [System.Serializable]
    public class Ellipse
    {
        public float xAxis = 5f;
        public float yAxis = 3f;

        public Vector2 Evaluate(float t)
        {
            float angle = Mathf.Deg2Rad * 360 * t;
            float x = Mathf.Sin(angle) * xAxis;
            float y = Mathf.Cos(angle) * yAxis;
            return new Vector2(x, y);
        }
    }
}