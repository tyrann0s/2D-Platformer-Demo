using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField]
    private StartingBlock startingBlock;

    [SerializeField]
    private List<GenBlock> blocks = new List<GenBlock>();

    private List<GameObject> createdBlocks = new List<GameObject>();
    public List<GameObject> CreatedBlocks => createdBlocks;

    private Vector3 spawnPosition;

    private Parallax parallax;

    private void Start()
    {
        parallax = FindObjectOfType<Parallax>();

        spawnPosition = Vector3.zero;

        Instantiate(startingBlock, spawnPosition, Quaternion.identity);
        parallax.AddBlocks(spawnPosition);

        spawnPosition = new Vector3(spawnPosition.x, startingBlock.transform.position.y);


        AddBlock();
        createdBlocks[0].GetComponent<GenBlock>().IsFirstBlock = true;

        startingBlock.SpawnPlayer();
    }

    public void AddBlock()
    {
        int rand = Random.Range(0, blocks.Count);

        GenBlock block = Instantiate(blocks[rand], spawnPosition, Quaternion.identity);

        createdBlocks.Add(block.gameObject);
        if (createdBlocks.Count > 2) createdBlocks[createdBlocks.Count - 3].GetComponent<GenBlock>().BlockExit();


        spawnPosition = new Vector3(spawnPosition.x + blocks[rand].GetWidth(), blocks[rand].transform.position.y);
        parallax.AddBlocks(spawnPosition);
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
