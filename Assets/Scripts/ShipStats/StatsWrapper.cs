using UnityEngine;

namespace SpaceCarrier.ShipStats
{
    //Wrap price sets in Editor because awake doesn't work with Scriptable Objects
    public class StatsWrapper : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] private ShipStat[] stats;

        private void Awake()
        {
            foreach(ShipStat stat in stats)
            { 
                stat.WrapPriceSets();
            }
        }
#endif
    }
}
