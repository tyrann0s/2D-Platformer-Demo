using UnityEngine;
using UnityEngine.Tilemaps;

public class Block : MonoBehaviour
{
    [SerializeField]
    private GameObject colliders;
    public GameObject Colliders => colliders;

    [SerializeField]
    private float colliderOffset;

    [SerializeField]
    private Tilemap groundTileMap;
    public Tilemap GroundTileMap => groundTileMap;

    private void Start()
    {
        foreach (Transform go in colliders.transform)
        {
            go.GetComponent<SpriteRenderer>().enabled = false;
            go.GetComponent<Collider2D>().offset = new Vector2(0, -colliderOffset);
        }
    }

    public float GetWidth()
    {
        return groundTileMap.cellBounds.size.x * GetComponent<Grid>().cellSize.x;
    }
}
