using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceCarrier.ShipStats
{
    public class StatsWrapper : MonoBehaviour
    {
        [SerializeField] private ShipStat[] stats;

        private void Awake()
        {
            foreach(ShipStat stat in stats)
            { 
                stat.WrapPriceSets();
            }
        }
    }
}
