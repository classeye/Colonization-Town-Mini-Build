using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler, IDropHandler, IDragHandler {
    [SerializeField]string tileName;
    [SerializeField]int baseFood;
    [SerializeField]int baseWood;
    [SerializeField]int baseMetal;

    public Tile(string tName, int bFood,int bWood,int bMetal) //constructor is here to give structure to newtiles created in list ??
    {
        tileName = tName;
        baseFood = bFood;
        baseWood = bWood;
        baseMetal = bMetal;
    }

    public void OnPointerClick(PointerEventData eventdata)
    {
        Debug.Log(this.gameObject.name + " got OnPointerClicked yo.");
    }

    public void OnDrag(PointerEventData eventdata)
    {
    }

    public void OnDrop(PointerEventData eventdata)
    {
        Debug.Log(this.gameObject.name + " got OnDropped ouch!");
    }
}
