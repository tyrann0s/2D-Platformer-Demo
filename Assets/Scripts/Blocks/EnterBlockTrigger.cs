using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBlockTrigger : MonoBehaviour
{
    private bool isActivated = false;

    private BlockManager blockManager;
    private Parallax parallax;

    private void Start()
    {
        blockManager = FindObjectOfType<BlockManager>();
        parallax = FindObjectOfType<Parallax>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isActivated)
        {
            blockManager.AddBlock();
            blockManager.DeleteOldBlock();

            parallax.AddBlocks();

            isActivated = true;

            FindObjectOfType<ThreatsManager>().IncreaseSpeed();
        }
    }
}
