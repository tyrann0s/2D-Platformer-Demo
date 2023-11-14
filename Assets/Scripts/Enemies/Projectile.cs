using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private bool isLeft;

    private Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Init(bool isMovingLeft)
    {
        isLeft = isMovingLeft;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Die();
        }

        Debug.Log("Getcoll " + collision.gameObject);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (isLeft) rigidbody2D.velocity =- transform.right * speed;
        else rigidbody2D.velocity =- transform.right * speed;
    }
}
