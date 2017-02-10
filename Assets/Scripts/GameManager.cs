using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    BoardManager BM;
    [SerializeField]
    CitizenManager CM;

    [Header ("CitizenManagement")]
    [SerializeField]
    CitizenScript storedCitizen;
    [SerializeField]
    bool holdingCitizen;


    void Awake()
    {
       //attach variable to BoardManager script
        BM = GetComponent<BoardManager>();
        CM = GetComponent<CitizenManager>();
        InitiateGame();
    }

    void InitiateGame()
    {
        BM.CreateBoard();
        BM.GenerateCitizens();
        CM.startManager(); 
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            click();
        }
    }

    private void click()
    {
        //raycast to check what is under mouse
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
        if (hit.collider.tag == "Citizen")
        {
            Debug.Log("it's a citizen, Jim");
            hit.collider.gameObject.GetComponent<CitizenScript>().GetClicked();
        }
    }

}
