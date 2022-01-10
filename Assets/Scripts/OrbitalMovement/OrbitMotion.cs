using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMotion : MonoBehaviour
{
    public Transform orbitingObject;
    public Ellipse orbitPath;

    [Range(0, 1f)] public float orbitProgress = 0f;
    public float orbitPeriod = 3f;
    public bool orbitActive = true;

    private void Start()
    {
        orbitPath.xAxis = transform.position.x;
        orbitPath.yAxis = transform.position.x;
        if (orbitingObject == null) 
        {
            orbitActive = false;
            return;
        }
        SetOrbitingObjectPosition();
        StartCoroutine(AnimateOrbit());
    }

    void SetOrbitingObjectPosition()
    { 
        Vector2 orbitPos = orbitPath.Evaluate(orbitProgress);
        orbitingObject.localPosition = new Vector3(orbitPos.x, 0, orbitPos.y);
    }

    IEnumerator AnimateOrbit()
    {
        if (orbitPeriod < .1f)
            orbitPeriod = .1f;
        float orbitSpeed = 1f / orbitPeriod;
        while (orbitActive)
        { 
            orbitProgress += Time.deltaTime * orbitSpeed;
            orbitProgress %= 1f;
            SetOrbitingObjectPosition();
            yield return null;
        }

    }
}
