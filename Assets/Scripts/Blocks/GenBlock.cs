using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenBlock : Block
{
    [SerializeField]
    private float scoreForCompletion;
    public float ScoreForCompletion => scoreForCompletion;

    public bool IsFirstBlock { get; set; }

    public Tilemap GetTilemap()
    {
        return GroundTileMap;
    }

    public TilemapRenderer GetTilemapRenderer()
    {
        return GetComponentInChildren<TilemapRenderer>();
    }
}
