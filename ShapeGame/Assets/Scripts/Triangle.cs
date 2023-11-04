using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Triangle : Shape
{
    public float zigzagSpeed = 2.0f;
    public override void Move()
    {
        base.Move();
        transform.Translate(Vector3.up * Mathf.Sin(Time.time *
       zigzagSpeed) * Time.deltaTime);
    }
}