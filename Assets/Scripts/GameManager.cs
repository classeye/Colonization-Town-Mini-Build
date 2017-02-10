using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    BoardManager boardScript;
    [SerializeField]
    CitizenManager citizenManager;

    
    void Awake()
    {
       //attach variable to BoardManager script
        boardScript = GetComponent<BoardManager>();
        citizenManager = GetComponent<CitizenManager>();
        InitiateGame();
    }

    void InitiateGame()
    {
        boardScript.CreateBoard();
        boardScript.GenerateCitizens();
        citizenManager.startManager(); 
    }

    
    

}
