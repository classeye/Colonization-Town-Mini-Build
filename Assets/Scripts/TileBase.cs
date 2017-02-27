using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TileBase : ScriptableObject
{
    public int tileNum;
    public string tileName;
    public int tileType; // 0: World Tile, 1: Town Tile
    public Sprite tileSprite;
    public int workerMax;
    
    [Header ("WorldTileStats")]
    public int baseFood;
    public int baseWood;
    public int baseOre;

    [Header("TownTileStats")]
    public int BaseHammers;  
}


