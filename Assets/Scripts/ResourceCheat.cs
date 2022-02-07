#if UNITY_EDITOR
using SpaceCarrier.Prefs;
using SpaceCarrier.Resoures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cheat to define any resource amount in the Editor
public class ResourceCheat : MonoBehaviour
{
    [SerializeField] int credits;
    [SerializeField] int purple;
    [SerializeField] int red;
    [SerializeField] int blue;
    [SerializeField] int green;
    [SerializeField] int brown;

    private void Start()
    {
        PlayerPrefs.SetInt(PrefsKeys.creditsKey, credits);
        PlayerPrefs.SetInt(PrefsKeys.homeResourcesKeys[ResourceTypes.Purple], purple);
        PlayerPrefs.SetInt(PrefsKeys.homeResourcesKeys[ResourceTypes.Red], red);
        PlayerPrefs.SetInt(PrefsKeys.homeResourcesKeys[ResourceTypes.Blue], blue);
        PlayerPrefs.SetInt(PrefsKeys.homeResourcesKeys[ResourceTypes.Green], green);
        PlayerPrefs.SetInt(PrefsKeys.homeResourcesKeys[ResourceTypes.Brown], brown);
    }
}
#endif