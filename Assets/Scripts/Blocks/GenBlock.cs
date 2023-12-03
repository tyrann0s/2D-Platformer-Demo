using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenBlock : Block
{
    public Tilemap GetTilemap()
    {
        return GroundTileMap;
    }

    public TilemapRenderer GetTilemapRenderer()
    {
        return GetComponentInChildren<TilemapRenderer>();
    }
}
