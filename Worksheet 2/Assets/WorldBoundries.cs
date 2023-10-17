using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class WorldBoundries : MonoBehaviour
{
    float minX, maxX, minY, maxY;
    Vector3 minViewport = new Vector3(0, 0);
    Vector3 maxViewport = new Vector3(1, 1);
    Vector3 mouseViewport;
    public GameObject Circle;
    int balls;
    void Start()
    {
        SetBoundries();
        SpawnCircles();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mouseViewport = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1") && balls < 5)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider == null)
            {
                balls++;
                Debug.Log("Creating circle at position: " + mouseViewport);
                Instantiate(Circle, new Vector3(mouseViewport.x, mouseViewport.y), Quaternion.identity);
            }
        }
    }

    void SetBoundries()
    {
        minX = Camera.main.ViewportToWorldPoint(minViewport).x;
        maxX = Camera.main.ViewportToWorldPoint(maxViewport).x;
        minY = Camera.main.ViewportToWorldPoint(minViewport).y;
        maxY = Camera.main.ViewportToWorldPoint(maxViewport).y;
        balls += 4;
    }

    void SpawnCircles()
    {
        Instantiate(Circle, new Vector3(minX + 1, minY + 1), Quaternion.identity);
        Instantiate(Circle, new Vector3(maxX - 1, minY + 1), Quaternion.identity);
        Instantiate(Circle, new Vector3(minX + 1, maxY - 1), Quaternion.identity);
        Instantiate(Circle, new Vector3(maxX - 1, maxY - 1), Quaternion.identity);
    }


}
