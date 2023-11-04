using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shape : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    // This method will move the shape forward
    public virtual void Move()
    {
        transform.Translate(Vector3.right * moveSpeed *
       Time.deltaTime);
    }
    private void Update()
    {
        Move();
    }
}