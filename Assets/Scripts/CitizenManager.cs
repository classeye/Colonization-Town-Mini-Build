using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenManager : MonoBehaviour {

    [SerializeField]
    CitizenScript selectedCitizen;
    [SerializeField]
    bool holdingCitizen;


    public void startManager()
    {
        holdingCitizen = false;
    }

    public void getCitizen(CitizenScript newCitizen)
    {
        if (holdingCitizen == false)
        {
            selectedCitizen = newCitizen;
            holdingCitizen = true;
        }
    }

    private void Update()
    {        
        if(holdingCitizen == true)
        {
            selectedCitizen.followMouse();
        }
    }


}
