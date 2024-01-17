using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    private Threat threat;

    private Player player;

    private void Awake()
    {
        threat = GetComponentInParent<Threat>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && threat.IsWorking && !collision.gameObject.GetComponent<Player>().IsImmortal)
        {
            Debug.Log("DamageCollider + " + threat.IsWorking);

            player = collision.gameObject.GetComponent<Player>();
            player.Die();
        }
    }
}
