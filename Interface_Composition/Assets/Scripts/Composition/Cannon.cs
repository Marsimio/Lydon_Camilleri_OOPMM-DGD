using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] float xspeed;
    public void Arc(Rigidbody2D rb)
    {
        rb.gravityScale = 0.98f;
        Vector2 myforce = new Vector2(xspeed, 0);
        rb.AddForce(myforce);
    }
}
