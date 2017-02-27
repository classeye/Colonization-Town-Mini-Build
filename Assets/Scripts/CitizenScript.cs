using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CitizenScript : MonoBehaviour{
    
    [SerializeField] TileScript currentTile;
    [SerializeField] Vector3 lastLocation;

    
    public void StartFollow()
    {
        currentTile.RemoveCitizen(this);
        lastLocation = transform.position;
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void FollowMouse()
    {
        Vector3 followPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);  
        transform.position = followPosition; 
    }

    public void ReturnHome()
    {
        transform.position = lastLocation;
        this.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void SetHome(TileScript newTile)
    {
        transform.position = newTile.transform.position;
        currentTile = newTile;
        this.GetComponent<BoxCollider2D>().enabled = true;
    }

}

