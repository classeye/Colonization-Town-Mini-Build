using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour {

    [SerializeField]
    bool holdingCitizen =false;

    [SerializeField]
    int currCitizens = 0;
    [SerializeField]
    int maxCitizens = 1;
    [SerializeField]
    List<CitizenScript> CitizensPresent;



    public bool CheckFull()
    {
        if (holdingCitizen)
        {
            return true;
        }
            return false;
    }

    public void addCitizen()
    {

    }

      
}
