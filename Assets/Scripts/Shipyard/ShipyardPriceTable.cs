using SpaceCarrier.ShipStats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceCarrier.Shipyard
{
    public class ShipyardPriceTable : MonoBehaviour
    {
        [SerializeField] private ShipStat engine;
        [SerializeField] private ShipStat maneurability;
        [SerializeField] private ShipStat mass;
        [SerializeField] private ShipStat cargoCapacity;
        [SerializeField] private ShipStat harvesting;

    }
}
