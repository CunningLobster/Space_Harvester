using SpaceCarrier.Resoures;
using SpaceCarrier.ShipStats;
using System.Collections.Generic;

namespace SpaceCarrier.Prefs
{
    public class PrefsKeys
    {
        public const string creditsKey = "Credits_Key";

        //On ship resources
        public static readonly Dictionary<ResourceTypes, string> shipResourcesKeys = new Dictionary<ResourceTypes, string>()
        {
            [ResourceTypes.Purple] = "S_Purple_Key",
            [ResourceTypes.Red] = "S_Red_Key",
            [ResourceTypes.Blue] = "S_Blue_Key",
            [ResourceTypes.Green] = "S_Green_Key",
            [ResourceTypes.Brown] = "S_Brown_Key"
        };

        //Home system resources
        public static readonly Dictionary<ResourceTypes, string> homeResourcesKeys = new Dictionary<ResourceTypes, string>()
        {
            [ResourceTypes.Purple] = "H_Purple_Key",
            [ResourceTypes.Red] = "H_Red_Key",
            [ResourceTypes.Blue] = "H_Blue_Key",
            [ResourceTypes.Green] = "H_Green_Key",
            [ResourceTypes.Brown] = "H_Brown_Key"
        };

        //Ship Stats
        public static readonly Dictionary<Stats, string> statsKeys = new Dictionary<Stats, string>()
        {
            [Stats.Engine] = "Engine_Key",
            [Stats.Maneurability] = "Maneurability_Key",
            [Stats.Mass] = "Mass_Key",
            [Stats.CargoCapacity] = "CargoCapacity_Key",
            [Stats.Harvesting] = "Harvesting_Key"
        };

    }
}