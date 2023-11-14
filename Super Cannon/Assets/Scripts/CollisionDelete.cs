using UnityEngine;

public class CollisionDelete : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Destroy the object when a "bullet" collides with it
            Destroy(collision.gameObject);
        }
    }
}