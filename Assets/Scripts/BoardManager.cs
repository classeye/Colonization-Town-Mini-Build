using UnityEngine;
using System;
using System.Collections.Generic;       //Allows us to use Lists.
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.

public class BoardManager : MonoBehaviour
{
    [Header("Board Generation Stuff")]
    public int columnAdjustment = 3;
    public int columns = 7;
    public int rows = 7;
    public GameObject tilePrefab; //base tile prefab, sprite and stats come from scriptableObjects


    [SerializeField] Transform boardHolder; //variable for the transform of the board
    [SerializeField] List<TileScript> worldTiles; //list of worldTiles generated

    [Header("Citizen Generation")]
    public GameObject[] CitizenPrefabs;
    public int numCitizens = 3;
    public List<TileScript> availableTiles;
    public ClickManager manager;

    public TileBase[] BaseWorldTiles; // where tile Scriptable objects exist


    public void CreateBoard()
    {
        boardHolder = new GameObject("Board").transform; // set boardholder to board transform

        string tileID; //string used to name generated tiles
        int tileIDx = -1; //first digit of tileID
        int tileIDy = -1; //second digit of tileID

        /// NEED TO FIGURE OUT HOW TO LOAD ASSETS INTO ARRAY PROPERLY
        //BaseWorldTiles = Resources.LoadAll("BaseTiles/WorldTiles") as TileBase[];
          

        for (int x = 0; x < columns; x++) //once for every column
        {
            tileIDx = x;
            for (int y = 0; y < rows; y++) //and once for every row
            {
                tileIDy = y;


                GameObject newTile = tilePrefab; //pull in the default tile
                TileBase tilePickBase = BaseWorldTiles[Random.Range(1, BaseWorldTiles.Length)]; //pick a scriptable object from array
                if (x == 3 && y == 3){ //if tile is 3-3 spawn a town tile;
                    tilePickBase = BaseWorldTiles[0];}

                newTile.GetComponent<TileScript>().SetType(tilePickBase);

                //then instantiate that chosen object at row/column in this for loop
                GameObject instance = Instantiate(newTile, new Vector3(x - columnAdjustment, y, 0f), Quaternion.identity); 
                instance.transform.SetParent(boardHolder);  //and parent it to boardholder

                tileID = tileIDx.ToString() + tileIDy.ToString(); // set name to "Tile" x coordinate y coordinate

                instance.gameObject.name = "Tile" + tileID;
                worldTiles.Add(instance.GetComponent<TileScript>());
                availableTiles.Add(instance.GetComponent<TileScript>());              
            }
        }
    }


    //
    //move to Citizen manager
    
    public void GenerateCitizens()
    {
        for (int colID = 0; colID < numCitizens; colID++)
        {
            //Debug.Log("ID " + colID);
            

            Vector3 bumVector = new Vector3(0f, 0f, 0f);
            GameObject colPick = CitizenPrefabs[Random.Range(0, CitizenPrefabs.Length)];
            GameObject instance = Instantiate(colPick, bumVector, Quaternion.identity);


            int randomIndex = Random.Range(0, availableTiles.Count); //picks a random tile coordinate
            TileScript tarTile = availableTiles[randomIndex]; //reserves coordinate for instantiation
            availableTiles.RemoveAt(randomIndex); //removes picked coordinate from list

            instance.GetComponent<CitizenScript>().SetHome(tarTile);
            tarTile.addCitizen(instance.GetComponent<CitizenScript>());

        }
    }
    
}




  
  
