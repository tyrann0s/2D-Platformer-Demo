using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBlockTrigger : MonoBehaviour
{
    private bool isActivated = false;

    private BlockManager blockManager;
    private GameManager gameManager;
    private Parallax parallax;
    private GenBlock genBlock;

    [SerializeField]
    private ParticleSystem vfx;

    [SerializeField]
    private SpriteRenderer flag;

    [SerializeField]
    private AudioSource enterSound;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        blockManager = FindObjectOfType<BlockManager>();
        parallax = FindObjectOfType<Parallax>();
        genBlock = GetComponentInParent<GenBlock>();

        if (genBlock.IsFirstBlock) flag.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isActivated)
        {
            blockManager.AddBlock();
            blockManager.DeleteOldBlock();

            parallax.AddBlocks();

            isActivated = true;
            if (!genBlock.IsFirstBlock)
            {
                gameManager.AddScore(genBlock.ScoreForCompletion, transform);
                vfx.Play();
                enterSound.Play();
            }

            FindObjectOfType<ThreatsManager>().IncreaseSpeed();
        }
    }
}
