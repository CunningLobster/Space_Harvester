using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceCarrier.Celestials
{
    public class CelestialResources : MonoBehaviour
    {
        [SerializeField] int currentResource = 20;
        public int CurrentResource { get => currentResource; set => currentResource = value; }

        public void Loose(int resourceAmount)
        {
            if (currentResource <= 0) return;
            currentResource = Mathf.Max(0, currentResource - resourceAmount);
        }
    }
}
