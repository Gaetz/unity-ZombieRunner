using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    private bool isHelicopterCalled;
    Rigidbody rbody;

    public void Start()
    {
        rbody = GetComponent<Rigidbody>();
        isHelicopterCalled = false;
    }

    void OnDispatchHelicopter()
    {
        if (!isHelicopterCalled)
        {
            // Bug, don't know why
            rbody = GetComponent<Rigidbody>();
            // End bug fix

            rbody.velocity = new Vector3(0, 0, 50f);
            isHelicopterCalled = true;
        }
    }
}
