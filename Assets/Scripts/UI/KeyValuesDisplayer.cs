using SpaceCarrier.Prefs;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//For Debug
public class KeyValuesDisplayer : MonoBehaviour
{
    TMP_Text creditKey;

    private void Awake()
    {
        creditKey = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        creditKey.text = $"Actual Credits: {PlayerPrefs.GetInt(PrefsKeys.creditsKey, 0).ToString()}";
    }
}
