using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private GameObject colliders;

    [SerializeField]
    private float colliderOffset;

    [SerializeField]
    private GameObject spawnPoint;

    private void Start()
    {
        foreach (Transform go in colliders.transform)
        {
            go.GetComponent<SpriteRenderer>().enabled = false;
            go.GetComponent<Collider2D>().offset = new Vector2 (0, -colliderOffset);
        }
    }

    public void RespawnPlayer(Player player)
    {
        player.transform.position = spawnPoint.transform.position;
    }
}
