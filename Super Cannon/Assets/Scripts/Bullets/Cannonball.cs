using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : Bullet
{

    [SerializeField] float xspeed;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        xSpeed();
    }

    // Update is called once per frame
    protected void xSpeed()
    {
        rb.gravityScale = 0.75f;
        Vector2 myforce = new Vector2(xspeed, 0);
        rb.AddForce(myforce);
    }
}
