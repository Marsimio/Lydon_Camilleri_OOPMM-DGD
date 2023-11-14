using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected Rigidbody2D rb;
    protected float xpseed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    protected virtual void Start()
    {
        Vector2 myforce = transform.up * speed;
        rb.AddForce(myforce, ForceMode2D.Impulse);
    }
}