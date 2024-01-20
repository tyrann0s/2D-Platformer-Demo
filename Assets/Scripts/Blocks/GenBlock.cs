using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenBlock : Block
{
    [SerializeField]
    private float scoreForCompletion;
    public float ScoreForCompletion => scoreForCompletion;

    [SerializeField]
    private GameObject blockObject;

    public bool IsFirstBlock { get; set; }

    public Tilemap GetTilemap()
    {
        return GroundTileMap;
    }

    public TilemapRenderer GetTilemapRenderer()
    {
        return GetComponentInChildren<TilemapRenderer>();
    }

    public void BlockExit()
    {
        StartCoroutine(TurnOnExitBlock());
    }

    private IEnumerator TurnOnExitBlock()
    {
        yield return new WaitForSeconds(.2f);
        if (blockObject != null) blockObject.SetActive(true);
    }
}
