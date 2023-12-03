using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField]
    private StartingBlock startingBlock;

    [SerializeField]
    private List<GenBlock> blocks = new List<GenBlock>();

    [SerializeField]
    private List<GameObject> createdBlocks = new List<GameObject>();

    private Vector3 spawnPosition;

    private void Start()
    {
        spawnPosition = Vector3.zero;

        Instantiate(startingBlock, spawnPosition, Quaternion.identity);
        spawnPosition = new Vector3(spawnPosition.x + startingBlock.GetWidth(), startingBlock.transform.position.y);

        AddBlock();

        startingBlock.SpawnPlayer();
    }

    public void AddBlock()
    {
        int rand = Random.Range(0, blocks.Count);

        GenBlock block = Instantiate(blocks[rand], spawnPosition, Quaternion.identity);
        createdBlocks.Add(block.gameObject);

        spawnPosition = new Vector3(spawnPosition.x + blocks[rand].GetWidth(), blocks[rand].transform.position.y);
    }

    public void DeleteOldBlock()
    {
        if (createdBlocks.Count > 3)
        {
            Destroy(createdBlocks[0]);
            createdBlocks.RemoveAt(0);
        }
    }
}
