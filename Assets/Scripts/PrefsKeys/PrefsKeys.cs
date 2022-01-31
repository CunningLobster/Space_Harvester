using SpaceCarrier.Resoures;
using System.Collections.Generic;

namespace SpaceCarrier.Prefs
{
    public class PrefsKeys
    {
        public const string creditsKey = "Credits_Key";

        //On ship resources
        public const string s_purpleKey = "S_Purple_Key";
        public const string s_redKey = "S_Red_Key";
        public const string s_blueKey = "S_Blue_Key";
        public const string s_greenKey = "S_Green_Key";
        public const string s_brownKey = "S_Brown_Key";
        public static readonly Dictionary<ResourceTypes, string> shipResourcesKeys = new Dictionary<ResourceTypes, string>()
        {
            [ResourceTypes.Purple] = s_purpleKey,
            [ResourceTypes.Red] = s_redKey,
            [ResourceTypes.Blue] = s_blueKey,
            [ResourceTypes.Green] = s_greenKey,
            [ResourceTypes.Brown] = s_brownKey
        };

        //Home system resources
        public const string h_purpleKey = "H_Purple_Key";
        public const string h_redKey = "H_Red_Key";
        public const string h_blueKey = "H_Blue_Key";
        public const string h_greenKey = "H_Green_Key";
        public const string h_brownKey = "H_Brown_Key";
        public static readonly Dictionary<ResourceTypes, string> homeResourcesKeys = new Dictionary<ResourceTypes, string>()
        {
            [ResourceTypes.Purple] = h_purpleKey,
            [ResourceTypes.Red] = h_redKey,
            [ResourceTypes.Blue] = h_blueKey,
            [ResourceTypes.Green] = h_greenKey,
            [ResourceTypes.Brown] = h_brownKey
        };

    }
}