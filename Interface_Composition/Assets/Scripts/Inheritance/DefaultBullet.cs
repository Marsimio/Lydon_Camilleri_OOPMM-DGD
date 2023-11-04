using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]


public class DefaultBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected float yspeed;
    [SerializeField] protected float xspeed;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    protected virtual void Start()
    {
        Vector2 myforce = new Vector2(0, yspeed);
        rb.AddForce(myforce);
    }
    protected void xSpeed()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.98f;
        Vector2 myforce = new Vector2(xspeed, 0);
        rb.AddForce(myforce);
    }

}
