using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {

    [SerializeField] CitizenScript storedCitizen;
    [SerializeField] bool holdingCitizen;
    
    public LayerMask layerCitizens;
    public LayerMask layerAll;


    public void startManager()
    {
        holdingCitizen = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //If left click
        {
            click(); //check for thing under mouse
        }

        if (holdingCitizen == true)
        {
            storedCitizen.FollowMouse();
        }
    }

    private void click()
    {   
        //select what layers to include or exclude
        LayerMask maskType = SelectLayer();
        //raycast checking for selected layer under mouse
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up, Mathf.Infinity, maskType);
        

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

    LayerMask SelectLayer()
    {
        if (holdingCitizen == true)
        {
            return ~layerCitizens;
        }
        return layerAll;
    }

    public void ClickWorldTile(TileScript clickedTile)
    {
        if (holdingCitizen)
        {
            if (clickedTile.CheckFull())
            {
                Debug.Log("clickTile was full");
                ReturnCitizen();
                return;
            }

            if (!clickedTile.CheckFull())
            {
                Debug.Log("clickTile was not full");
                clickedTile.addCitizen(storedCitizen);
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
