using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedForce : MonoBehaviour
{
    Vector3 force = new Vector3();
    Rigidbody rb;
    ForceInfluencer[] forceInfluencers;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        forceInfluencers = FindObjectsOfType<ForceInfluencer>();
    }

    private void FixedUpdate()
    {
        force = GetResultForce();
        rb.AddForce(force);
        Debug.Log(force);
    }

    Vector3 GetResultForce()
    {
        Vector3 result = new Vector3();
        foreach (var influencer in forceInfluencers)
        { 
            result += influencer.GetForce();
        }
        return result;
    }
}
