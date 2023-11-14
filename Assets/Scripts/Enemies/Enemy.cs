using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Threat
{
    [SerializeField]
    private float jumpImpulseOnDeath;

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
        Debug.Log(gameObject + " died");
        Destroy(gameObject);
    }
}
