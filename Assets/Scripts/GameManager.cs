using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private BoardManager boardScript;

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

}
