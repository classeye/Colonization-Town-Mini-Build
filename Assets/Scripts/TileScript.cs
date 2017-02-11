using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour {
    [SerializeField]
    bool holdingCitizen =false;


    /*
    [SerializeField]string tileName;
    [SerializeField]int baseFood;
    [SerializeField]int baseWood;
    [SerializeField]int baseMetal;

    public Tile(string tName, int bFood,int bWood,int bMetal) //constructor is here to give structure to newtiles created in list ??
    {
        tileName = tName;
        baseFood = bFood;
        baseWood = bWood;
        baseMetal = bMetal;
    }
    */

    public bool CheckFull()
    {
        if (holdingCitizen)
        {
            return true;
        }
            return false;
    }

      
}
