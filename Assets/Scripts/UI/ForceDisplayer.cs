using SpaceCarrier.Physics;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ForceDisplayer : MonoBehaviour
{
    [SerializeField] TMP_Text forceMg;
    [SerializeField] AttachedForce af;

    private void Update()
    {
        forceMg.text = af.Force.magnitude.ToString();
    }
}
