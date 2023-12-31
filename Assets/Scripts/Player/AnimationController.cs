using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Idle()
    {
        animator.Play("Idle");
    }

    public void Run()
    {
        animator.Play("Run");
    }

    public void Jump()
    {
        animator.Play("Jump");
    }

    public void Fall()
    {
        animator.Play("Fall");
    }
}
