using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColonistScript : MonoBehaviour, IPointerClickHandler{
    
    [SerializeField]bool isFollowing;
    [SerializeField]GameObject currentTile;
    [SerializeField]GameManager GM;


    public void SetManager(GameManager manager) {
        GM = manager;
    }
    

    void Start()
    {
        isFollowing = false;
    }

    void Update()
    {
        if (isFollowing)
        {
            followMouse();
        }
    }

    public void OnPointerClick(PointerEventData eventdata)
    {
        //isFollowing = !isFollowing;
    }

    void followMouse()
    {
        Vector3 followPosition;
        followPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);  
        transform.position = followPosition; 
    }

    /*
    public void reassign (GameObject tarTile)
    {
        transform.position = tarTile.transform.position;
    }
    */
}

