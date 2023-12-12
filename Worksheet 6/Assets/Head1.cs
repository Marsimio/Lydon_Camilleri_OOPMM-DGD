using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public GameObject headShape;
    public void CreateHead()
    {
        Instantiate(headShape, transform.position,
       Quaternion.identity, transform);
    }
}

