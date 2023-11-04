using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Square : Shape
{
    public float jumpHeight = 2.0f;
    public override void Move()
    {
        base.Move();
        if (Mathf.Sin(Time.time) > 0)
        {
            transform.Translate(Vector3.up * jumpHeight *
           Time.deltaTime);
        }
        
    }
}
