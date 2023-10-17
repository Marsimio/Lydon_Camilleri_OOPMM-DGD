using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 moving;
    public float movement;

    private void Start()
    {
        
    }
    void FixedUpdate()
    {
        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + moving;
        }
        MoveCircle();
    }

    private void OnMouseDown()
    {
        moving = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }
    void MoveCircle()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, movement);
    }
}
