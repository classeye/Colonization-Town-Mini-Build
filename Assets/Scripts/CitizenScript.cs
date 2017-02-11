using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CitizenScript : MonoBehaviour{
    
    [SerializeField]GameObject currentTile;
    [SerializeField]Vector3 lastLocation;

    
    public void StartFollow()
    {
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
        this.GetComponent<BoxCollider2D>().enabled = true;
    }

}

