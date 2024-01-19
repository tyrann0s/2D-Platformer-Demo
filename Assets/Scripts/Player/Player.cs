using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed, maxVelocity;

    [SerializeField]
    private float jumpForce;
    private float jumpForceAdd;

    private bool isMovingLeft, isMovingRight, isJumping, isGrounded;

    private AnimationController animationController;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public bool IsImmortal { get; private set; }

    [Header("Sounds")]
    [SerializeField]
    private List<AudioSource> fStepSounds = new List<AudioSource>();
    [SerializeField]
    private float fStepInterval;
    [SerializeField]
    private AudioSource jumpSound, landSound, deathSound;

    private bool isDead = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animationController = GetComponent<AnimationController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        CameraScript cam = FindObjectOfType<CameraScript>();
        cam.SetUpCamera(this);
    }

    private void Update()
    {
        isMovingLeft = Input.GetKey(KeyCode.LeftArrow) && !isDead;
        isMovingRight = Input.GetKey(KeyCode.RightArrow) && !isDead;

        if (isGrounded) isJumping |= Input.GetKeyDown(KeyCode.UpArrow) && !isDead;
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
            StartCoroutine(HoldJump());
            JumpImpulse(jumpForce);
            isJumping = false;
        }

        Vector3 clampedVelocity = rb.velocity;
        clampedVelocity.x = Mathf.Clamp(clampedVelocity.x, -maxVelocity, maxVelocity);

        rb.velocity = clampedVelocity;
    }

    private void LateUpdate()
    {
        if ( rb.velocity.y < 0 && !isGrounded && !isDead)
        {
            animationController.Fall();
        }

        if (rb.velocity.y > 0 && !isDead)
        {
            animationController.Jump();
        }

        if (rb.velocity.x < 0 && isGrounded && !isDead)
        {
            animationController.Run();
        }

        if (rb.velocity.x > 0 && isGrounded && !isDead)
        {
            animationController.Run();
        }

        if (rb.velocity == Vector2.zero && !isDead) animationController.Idle();
    }

    private void FStepSoundPlay()
    {
        int rand = Random.Range(0, fStepSounds.Count);
        fStepSounds[rand].Play();
    }

    private void JumpSoundPlay()
    {
        if (!jumpSound.isPlaying) jumpSound.Play();
    }

    public void JumpImpulse(float force)
    {
        if (!isDead) rb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    private IEnumerator HoldJump()
    {
        while (Input.GetKey(KeyCode.UpArrow))
        {
            jumpForceAdd += .5f;
            if (jumpForceAdd >= 1)
            {
                JumpImpulse(jumpForceAdd); break;
            }
            yield return new WaitForSeconds(.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            jumpForceAdd = 0f;
            if (!landSound.isPlaying) landSound.Play();
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
        isDead = true;
        GetComponent<Collider2D>().enabled = false;
        AudioSource.PlayClipAtPoint(deathSound.clip, transform.position);

        rb.AddForce(-transform.right * 1f, ForceMode2D.Impulse);
        rb.AddForce(transform.up * 3f, ForceMode2D.Impulse);

        animationController.Dissolve();
        StartCoroutine(DeathTimer());
    }

    private IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<GameManager>().PlayerDied();
        Destroy(gameObject);
    }

    public void SetGodMode(bool value)
    {
        IsImmortal = value;
    }
}
