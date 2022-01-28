using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceCarrier.SpaceShips;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    Rigidbody rb;
    Vector3 force;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //if (Keyboard.current.dKey.isPressed)
        //{
        //    print("d pressed");
        //    rb.AddForce(10f, 0, 0);
        //}

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            print("a pressed");
            rb.AddForce(-10f, 0, 0);
        }

    }
}
