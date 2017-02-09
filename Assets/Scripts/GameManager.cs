using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    BoardManager boardScript;
    [SerializeField]
    CitizenManager citizenManager;

    [SerializeField]bool holdingColonist;


    //public ColonistScript selectedColonist;

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
