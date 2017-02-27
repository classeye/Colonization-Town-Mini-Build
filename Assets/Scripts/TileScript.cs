using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour {

    [SerializeField] int currCitizens = 0;
    [SerializeField] int maxCitizens = 1;
    [SerializeField] List<CitizenScript> CitizensPresent;

    public TileBase _base; //ScriptableObject determining base stats;

    [SerializeField] int currFood;
    [SerializeField] int currWood;
    [SerializeField] int currOre;

    [SerializeField] int currHammers;

    public bool CheckFull()
    {
        if (currCitizens == maxCitizens)
        {
            return true;
        }
            return false;
    }

    public void addCitizen(CitizenScript target)
    {
        CitizensPresent.Add(target);
        ++currCitizens;
    }

    public void RemoveCitizen(CitizenScript target)
    {
        CitizensPresent.Remove(target);
        --currCitizens;
    }

    public void SetType(TileBase _pushedBase)
    {
        _base = _pushedBase;
        this.GetComponent<SpriteRenderer>().sprite = _base.tileSprite;
    }

    
}