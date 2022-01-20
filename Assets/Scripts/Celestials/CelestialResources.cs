using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceCarrier.Celestials
{
    public class CelestialResources : MonoBehaviour
    {
        [SerializeField] ResourceDisplayer resourceDisplayer;

        [SerializeField] ResourceTypes resourceType;
        public ResourceTypes ResourceType { get => resourceType; }

        [SerializeField] int currentResource = 20;
        public int CurrentResource { get => currentResource; set => currentResource = value; }

        private void Start()
        {
            resourceDisplayer.SetValue(currentResource);
        }

        public void Loose(int resourceAmount)
        {
            if (currentResource <= 0) return;
            currentResource = Mathf.Max(0, currentResource - resourceAmount);
            resourceDisplayer.SetValue(currentResource);
        }
    }
}
