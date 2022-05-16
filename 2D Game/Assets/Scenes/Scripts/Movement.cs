using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public Transform firePoint;

    public float speed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            if(!animator.GetBool("IsCrouching"))
            {
                animator.SetBool("IsJumping", true);
            }
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            firePoint.Translate(+0.15f, -0.36f, 0f);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            firePoint.Translate(-0.15f, +0.36f, 0f);
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
