using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameData : MonoBehaviour

{

    private static Vector3 mousePos;
    private static float padding = 0f;
    private static int _playerHealth = 10;
    private static int score = 0;

    public static int PlayerHealth
    {
        get { return _playerHealth; }
        set { _playerHealth = value;}
    }

    public static int Score
    {
        get { return score; }
        set { score = value; }
    }

    public static Vector3 MousePos

    {
        get { return GetMousePos(); }
    }

    private static Vector3 GetMousePos()

    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, 10f);
        return mousePos;

    }

    public static float XMin

    {

        get { return Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding; }

    }

    public static float YMin

    {

        get { return Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding; }

    }

    public static float XMax

    {

        get { return Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding; }

    }

    public static float YMax

    {

        get { return Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding; }

    }


}