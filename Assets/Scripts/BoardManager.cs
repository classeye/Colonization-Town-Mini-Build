using UnityEngine;
using System;
using System.Collections.Generic;       //Allows us to use Lists.
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.

public class BoardManager : MonoBehaviour
{
    [Header("Board Generation Tile Stuff")]
    public int columns = 7;
    public int rows = 7;
    public GameObject[] tilePrefabs; //an array loaded with world tile objects
    public GameObject townTile; // the variable the town object will be stored in
    private Transform boardHolder; //variable for the transform of the board

    public GameObject[] ColonistPrefabs;
    public int numColonists = 3;

    public List<Vector3> availableTiles;

    public GameManager manager;



    public void CreateBoard() //called by GameManager
    {
        //
        //move to colonist manager
        //
        manager = GetComponent<GameManager>(); //move to colonist manager

        boardHolder = new GameObject("Board").transform; // set boardholder to board transform

        string tileID; //string used to nme generated tiles
        int tileIDx = -1; //first digit of tileID
        int tileIDy = -1; //second digit of tileID
        


        for (int x = 0; x < columns; x++) //once for every column
        {
            tileIDx++;
            
            for (int y = 0; y < rows; y++) //and once for every row
            {
                tileIDy++;

                Vector3 newTileVector = new Vector3(x, y, 0f);
                availableTiles.Add(newTileVector);
                                
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
    //move to colonist manager
    //
    public void GenerateColonists()
    {
        for (int colID = 0; colID < numColonists; colID++)
        {
            //Debug.Log("ID " + colID);
            int randomIndex = Random.Range(0, availableTiles.Count); //picks a random tile coordinate
            Vector3 newColVector = availableTiles[randomIndex]; //reserves coordinate for instantiation
            availableTiles.RemoveAt(randomIndex); //removes picked coordinate from list
            GameObject colPick = ColonistPrefabs[Random.Range(0, ColonistPrefabs.Length)];
            GameObject instance = Instantiate(colPick, newColVector, Quaternion.identity);
            instance.GetComponent<ColonistScript>().SetManager(manager);
            
        }
    }
}




  
  
