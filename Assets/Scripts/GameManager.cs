using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    BoardManager BM;
    [SerializeField]
    ClickManager CM;

    void Awake()
    {
       //attach variable to BoardManager script
        BM = GetComponent<BoardManager>();
        CM = GetComponent<ClickManager>();
        InitiateGame();
    }

    void InitiateGame()
    {
        BM.CreateBoard();
        BM.GenerateCitizens();
        CM.startManager(); 
    }


    

}
