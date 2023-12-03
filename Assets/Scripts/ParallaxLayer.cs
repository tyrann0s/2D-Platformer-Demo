using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using static UnityEditor.FilePathAttribute;
using static UnityEditor.PlayerSettings;
using static UnityEditor.ShaderData;

public class ParallaxLayer : MonoBehaviour
{
    private Tilemap tilemap;

    [SerializeField]
    private float speed;
    public float Speed => speed;

    public float Lenght { get; private set; }
    public float StartPosition { get; set; }

    public Vector3 SpawnPosition { get; private set; }

    [SerializeField]
    private float floatForce, floatSpeed;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void Start()
    {
        StartPosition = transform.position.x;
        StartCoroutine(Float());
    }

    public void LoadBlock(GenBlock block)
    {
        Tilemap ogTilemap = block.GetTilemap();
        Lenght = ogTilemap.localBounds.size.x;

        BoundsInt bounds = ogTilemap.cellBounds;
        TileBase[] tiles = ogTilemap.GetTilesBlock(bounds);

        BuildTiles(bounds, tiles);
    }

    private void BuildTiles(BoundsInt bounds, TileBase[] tiles)
    {
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = tiles[x + y * bounds.size.x];
                Vector3Int pos = new Vector3Int(x, y, 0);
                if (tile != null)
                {
                    tilemap.SetTile(pos, tile);
                }
                else
                {
                    tilemap.SetTile(pos, null);
                }
            }
        }

        tilemap.CompressBounds();
        SpawnPosition = new Vector3(transform.position.x + GetWidth(), transform.position.y);
    }

    private float GetWidth()
    {
        return tilemap.cellBounds.size.x * GetComponentInParent<Grid>().cellSize.x;
    }

    private IEnumerator Float()
    {
        Vector3 origin = tilemap.tileAnchor;
        Vector3 target = new Vector3(tilemap.tileAnchor.x, tilemap.tileAnchor.y + floatForce, tilemap.tileAnchor.z);

        for (;;)
        {
            while (tilemap.tileAnchor.y < target.y)
            {
                tilemap.tileAnchor = Vector3.MoveTowards(tilemap.tileAnchor, target, floatSpeed * Time.deltaTime);
                yield return null;
            }

            while (tilemap.tileAnchor.y > origin.y)
            {
                tilemap.tileAnchor = Vector3.MoveTowards(tilemap.tileAnchor, origin, floatSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
}
