using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColonistScript : MonoBehaviour, IPointerClickHandler{

    bool isFollowing;

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
        isFollowing = !isFollowing;
    }

    void followMouse()
    {
        Vector3 followPosition;
        followPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);  
        transform.position = followPosition; 
    }
}

