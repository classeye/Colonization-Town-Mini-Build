using UnityEngine;
using System;
using System.Collections.Generic;       //Allows us to use Lists.
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.

public class BoardManager : MonoBehaviour
{
    public int columns = 7;
    public int rows = 7;
    public GameObject[] Tiles; //an array loaded with world tile objects
    public GameObject townTile; // the variable the town object will be stored in
    private Transform boardHolder; //variable for the transform of the board
    private string tileID;


    public void CreateBoard() //called by GameManager
    {
        boardHolder = new GameObject("Board").transform; // set boardholder to board transform

        int tileNum = new int();
        tileNum = 0;

        //once for every column
        for (int x = 0; x < columns; x++)
        {
            //and once for every row
            for (int y = 0; y < rows; y++)
            {
                tileNum++;

                //instantiate a tile from the world tiles list
                GameObject toInstantiate = Tiles[Random.Range(0, Tiles.Length)];
                //unless it is tile 3,3. in which case load the town tile
                if (x == 3 && y == 3)
                {
                toInstantiate = townTile;
                }
                //the instantiate that chosen object at row/column in this for loop
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity);
                //and parent it to boardholder
                instance.transform.SetParent(boardHolder);
                //instance.gameObject.name = "Tile" + tileID;
                if (tileNum < 10)
                {
                    tileID = "0" + tileNum.ToString();
                }
                else
                {
                    tileID = tileNum.ToString();
                }


                instance.gameObject.name = "Tile" + tileID;
            }
         
                
                    
   

            }
        }
    }

  
  
