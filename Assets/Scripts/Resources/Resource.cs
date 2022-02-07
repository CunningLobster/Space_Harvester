using UnityEngine;

namespace SpaceCarrier.Resoures
{
    //Used only for displaying ship stats upgrade prices
    [CreateAssetMenu(fileName = "Resource", menuName = "ScriptableObjects/SpawnResource", order = 2)]
    public class Resource : ScriptableObject
    {
        [SerializeField] private ResourceTypes type;
        [SerializeField] private Sprite sprite;

        public Sprite Sprite { get => sprite; }
        public ResourceTypes Type { get => type; }
    }
}