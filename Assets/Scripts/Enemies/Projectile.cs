using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private bool isLeft;

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void Init(bool isMovingLeft, float speedMod)
    {
        isLeft = isMovingLeft;

        speed *= speedMod / 2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !collision.gameObject.GetComponent<Player>().IsImmortal)
        {
            collision.gameObject.GetComponent<Player>().Die();
        }

        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (isLeft) rb2D.velocity =- transform.right * speed;
        else rb2D.velocity =- -transform.right * speed;
    }
}
