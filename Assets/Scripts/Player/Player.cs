using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed, maxVelocity;

    [SerializeField]
    private float jumpForce;

    private bool isMovingLeft, isMovingRight, isJumping, isGrounded;

    private AnimationController animationController;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animationController = GetComponent<AnimationController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        isMovingLeft = Input.GetKey(KeyCode.LeftArrow);
        isMovingRight = Input.GetKey(KeyCode.RightArrow);
        if (isGrounded) isJumping |= Input.GetKeyDown(KeyCode.UpArrow);
    }

    private void FixedUpdate()
    {
        if (isMovingLeft)
        {
            rb.AddForce(-transform.right * movementSpeed);
            spriteRenderer.flipX = true;
        }

        if (isMovingRight)
        {
            rb.AddForce(transform.right * movementSpeed);
            spriteRenderer.flipX = false;
        }

        if (isJumping)
        {
            JumpImpulse(jumpForce);
            isJumping = false;
        }

        Vector3 clampedVelocity = rb.velocity;
        clampedVelocity.x = Mathf.Clamp(clampedVelocity.x, -maxVelocity, maxVelocity);

        rb.velocity = clampedVelocity;
    }

    private void LateUpdate()
    {
        if ( rb.velocity.y < 0 && !isGrounded)
        {
            animationController.Fall();
        }

        if (rb.velocity.y > 0)
        {
            animationController.Jump();
        }

        if (rb.velocity.x < 0 && isGrounded)
        {
            animationController.Run();
            
        }

        if (rb.velocity.x > 0 && isGrounded)
        {
            animationController.Run();
            
        }

        if (rb.velocity == Vector2.zero) animationController.Idle();
    }

    public void JumpImpulse(float force)
    {
        rb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    public void Die()
    {
        Block block = FindObjectOfType<Block>();
        block.RespawnPlayer(this);
    }
}
