using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{

    Rigidbody2D rb;
    private FireUp gunFire;
    private Cannon cannonFire;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Start()
    {
        gunFire = GetComponent<FireUp>();
        cannonFire = GetComponent<Cannon>();

        if (gunFire != null) gunFire.Fire(rb);
        try
        {
            cannonFire.Arc(rb);
        }
        catch (NullReferenceException ex)
        {
            Debug.Log("No horizontal firing");
        }
    }

}
