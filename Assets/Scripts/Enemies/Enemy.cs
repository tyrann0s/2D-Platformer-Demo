using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Threat
{
    [SerializeField]
    private float jumpImpulseOnDeath;

    [SerializeField]
    private float scoreForKill;

    private GameManager gameManager;

    [SerializeField]
    private AudioSource deathSound;

    private Player player;

    [SerializeField]
    private DamageCollider damageCollider;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !damageCollider.GetComponent<Collider2D>().IsTouching(collision.collider))
        {
            player = collision.gameObject.GetComponent<Player>();

            IsWorking = false;

            if (GetComponentInChildren<DamageCollider>() != null) GetComponentInChildren<DamageCollider>().gameObject.SetActive(false);
            if (player != null) player.JumpImpulse(jumpImpulseOnDeath);
            Die();
        }
    }

    private void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound.clip, transform.position);
        gameManager.AddScore(scoreForKill, transform);

        if (GetType() == typeof(BasicEnemy)) GetComponentInParent<EnemyMover>().Destroy();

        Destroy(gameObject);
    }
}
