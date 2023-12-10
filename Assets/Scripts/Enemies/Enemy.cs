using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Threat
{
    [SerializeField]
    private float jumpImpulseOnDeath;

    [SerializeField]
    private float scoreForKill;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GetComponentInChildren<DamageCollider>() != null) GetComponentInChildren<DamageCollider>().gameObject.SetActive(false);
            collision.gameObject.GetComponent<Player>().JumpImpulse(jumpImpulseOnDeath);
            Die();
        }
    }

    private void Die()
    {
        gameManager.AddScore(scoreForKill, transform);
        Destroy(gameObject);
    }
}
