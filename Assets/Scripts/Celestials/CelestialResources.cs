using UnityEngine;

namespace SpaceCarrier.Celestials
{
    public class CelestialResources : MonoBehaviour
    {
        [SerializeField] private ResourceDisplayer resourceDisplayer;

        [SerializeField] private ResourceTypes resourceType;
        public ResourceTypes ResourceType { get => resourceType; }

        [SerializeField] private int currentResource = 20;
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
