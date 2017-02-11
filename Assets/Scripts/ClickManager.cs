using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {

    [SerializeField]
    CitizenScript storedCitizen;
    [SerializeField]
    bool holdingCitizen;


    public void startManager()
    {
        holdingCitizen = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //If left click
        {
            click();
        }

        if (holdingCitizen == true)
        {
            storedCitizen.FollowMouse();
        }
    }

    private void click()
    {
        //raycast to check what is under mouse
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
        if (hit.collider == null)
        {
            Debug.Log("hit nothing");
            return;
        }

        if (hit.collider.tag == "Citizen")
        {
            //Debug.Log("it's a citizen, Jim");
            clickCitizen(hit.collider.gameObject.GetComponent<CitizenScript>());
            return;
        }

        if (hit.collider.tag == "WorldTile")
        {
            Debug.Log("Clicked " + hit.collider.gameObject.name);
            ClickWorldTile(hit.collider.gameObject.GetComponent<TileScript>());
            return;
        }
    }
    //-----------------------------------
    //-----------------------------------

        
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
            ReturnCitizen();
        }
    }

    public void ClickWorldTile(TileScript clickedTile)
    {
        if (holdingCitizen)
        {
            if (clickedTile.CheckFull())
            {
                ReturnCitizen();
                return;
            }

            if (!clickedTile.CheckFull())
            {
                PlaceCitizen(clickedTile);
            }
        }
    }

    //void TakeCitizen()

    void ReturnCitizen()
    {
        holdingCitizen = false;
        storedCitizen.ReturnHome();
        storedCitizen = null;
        return;
    }

    void PlaceCitizen(TileScript newHome)
    {
        holdingCitizen = false;
        storedCitizen.SetHome(newHome);
        storedCitizen = null;

    }

}
