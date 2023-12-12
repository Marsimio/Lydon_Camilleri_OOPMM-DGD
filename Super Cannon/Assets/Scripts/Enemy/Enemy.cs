using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int start_hitpoints;
    public int start_strength;
    public float start_speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Floor"))
        {
            GameData.PlayerHealth -= start_strength;
            Debug.Log("Player Health: " + GameData.PlayerHealth.ToString());
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag.Contains("Bullet"))
        {
            start_hitpoints -= 1;
            if (start_hitpoints <= 0)
            {
                Destroy(this.gameObject);
            }
        }

    }
}
