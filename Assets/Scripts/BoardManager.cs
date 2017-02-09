using UnityEngine;
using System;
using System.Collections.Generic;       //Allows us to use Lists.
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.

public class BoardManager : MonoBehaviour
{
    [Header("Board Generation Tile Stuff")]
    public int columns = 7;
    public int columnAdjustment = 3;
    public int rows = 7;
    public GameObject[] tilePrefabs; //an array loaded with world tile objects
    public GameObject townTile; // the variable the town object will be stored in
    private Transform boardHolder; //variable for the transform of the board

    public GameObject[] CitizenPrefabs;
    public int numCitizens = 3;

    public List<Vector3> availableTiles;

    public CitizenManager manager;



    public void CreateBoard() //called by CitizenManager
    {
        //
        //move to Citizen manager
        //
        manager = GetComponent<CitizenManager>(); //move to Citizen manager

        boardHolder = new GameObject("Board").transform; // set boardholder to board transform

        string tileID; //string used to nme generated tiles
        int tileIDx = -1; //first digit of tileID
        int tileIDy = -1; //second digit of tileID
        


        for (int x = (0-columnAdjustment); x < (columns- columnAdjustment); x++) //once for every column
        {
            tileIDx++;
            
            for (int y = 0; y < rows; y++) //and once for every row
            {
                tileIDy++;

                Vector3 newTileVector = new Vector3(x, y, 0f);
                availableTiles.Add(newTileVector);

                List<Vector3> someTiles = new List<Vector3>();
                someTiles.Add(newTileVector);
                                
                GameObject tilePick = tilePrefabs[Random.Range(0, tilePrefabs.Length)]; //instantiate a tile from the world tiles list
                if (x == 3 && y == 3) //unless it is tile 3,3. in which case load the town tile
                {
                tilePick = townTile;
                }

                GameObject instance = Instantiate(tilePick, new Vector3(x, y, 0f), Quaternion.identity); //the instantiate that chosen object at row/column in this for loop
                instance.transform.SetParent(boardHolder);  //and parent it to boardholder

                tileID = tileIDx.ToString() + tileIDy.ToString(); // set name to "Tile" x coordinate y coordinate
                instance.gameObject.name = "Tile" + tileID;
            }
            }
        }

    //
    //move to Citizen manager
    //
    public void GenerateCitizens()
    {
        for (int colID = 0; colID < numCitizens; colID++)
        {
            //Debug.Log("ID " + colID);
            int randomIndex = Random.Range(0, availableTiles.Count); //picks a random tile coordinate
            Vector3 newColVector = availableTiles[randomIndex]; //reserves coordinate for instantiation
            availableTiles.RemoveAt(randomIndex); //removes picked coordinate from list
            GameObject colPick = CitizenPrefabs[Random.Range(0, CitizenPrefabs.Length)];
            GameObject instance = Instantiate(colPick, newColVector, Quaternion.identity);
            instance.GetComponent<CitizenScript>().SetManager(manager);
            
        }
    }
}




  
  
