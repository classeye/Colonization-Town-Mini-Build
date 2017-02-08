using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private BoardManager boardScript;

    //public ColonistScript selectedColonist;

    void Awake()
    {
       //attach variable to BoardManager script
        boardScript = GetComponent<BoardManager>();
        InitiateGame();
    }

    void InitiateGame()
    {
        boardScript.CreateBoard();
        boardScript.GenerateColonists();
    }

    /*
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Click");
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right Click");
        }
        
    }
    */

}
