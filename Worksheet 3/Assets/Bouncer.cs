using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField] int health;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * 200f);
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        health -= 10;
        Debug.Log(health);
        Color color = GetComponent<SpriteRenderer>().color;
        color.a -= 0.1f;
        GetComponent<SpriteRenderer>().color = color;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
