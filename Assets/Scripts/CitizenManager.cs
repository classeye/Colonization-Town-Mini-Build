using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenManager : MonoBehaviour {

    [SerializeField]
    CitizenScript storedCitizen;
    [SerializeField]
    bool holdingCitizen;


    public void startManager()
    {
        holdingCitizen = false;
    }


    public void clickCitizen(CitizenScript clickedCitizen)
    {
        if (!holdingCitizen)
        {
            storedCitizen = clickedCitizen;
            storedCitizen.StartFollow();
            holdingCitizen = true;
            return;
        }

        if (holdingCitizen) //testing logic, will need to change once start designing 
        {
            holdingCitizen = false;
            storedCitizen.ReturnHome();
            storedCitizen = null;        
        }
    }


    private void Update()
    {        
        if(holdingCitizen == true)
        {
            storedCitizen.FollowMouse();
        }
    }


   


}
