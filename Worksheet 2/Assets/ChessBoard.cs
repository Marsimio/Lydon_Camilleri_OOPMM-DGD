using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public GameObject blackSquare;
    public GameObject redSquare;
    public int boardSize = 8;
    List<GameObject> squares = new List<GameObject>();
    bool isRed = false;
    Vector3 minViewport = new Vector3(0, 0);
    float minX, minY;

    void Start()
    {
        SetBoundries();
        CreateChessboard();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleColors();
        }
    }

    void SetBoundries()
    {
        minX = Camera.main.ViewportToWorldPoint(minViewport).x;
        minY = Camera.main.ViewportToWorldPoint(minViewport).y;
    }
    void CreateChessboard()
    {



        for (float x = minX; x < boardSize; x++)
        {
            for (float y = minY; y < boardSize; y++)
            {
                GameObject squareColor = isRed ? redSquare : blackSquare;
                GameObject square = Instantiate(squareColor, new Vector3(x+0.5f, y+0.5f, 10) , Quaternion.identity);
                squares.Add(square);
                square.transform.parent = transform;
                isRed = !isRed;
            }
            isRed = !isRed;
        }
    }

    void ToggleColors()
    {
        foreach (GameObject square in squares)
        {
            if (square.GetComponent<SpriteRenderer>().color == Color.black)
            {
                square.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                square.GetComponent<SpriteRenderer>().color = Color.black;
            }
        }
    }
}
