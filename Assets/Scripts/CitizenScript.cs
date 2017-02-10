using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CitizenScript : MonoBehaviour, IPointerClickHandler{
    
    [SerializeField]GameObject currentTile;
    [SerializeField]CitizenManager CM;
    [SerializeField]Vector3 lastLocation;


    public void SetManager(CitizenManager manager) {
        CM = manager;
    }

    void Update()
    {
    }

    public void OnPointerClick(PointerEventData eventdata)
    {        
        CM.clickCitizen(this);
        Debug.Log(gameObject.name + " was clicked");   
    }

    public void StartFollow()
    {
        lastLocation = transform.position;
    }

    public void ReturnHome()
    {
        transform.position = lastLocation;
    }

    public void FollowMouse()
    {
        Vector3 followPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);  
        transform.position = followPosition; 
    }
}

