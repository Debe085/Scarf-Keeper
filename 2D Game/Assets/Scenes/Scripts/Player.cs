using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float life = 120f;
    private Rigidbody2D rb;
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
            crouch = false;
            firePoint.Translate(-0.15f, +0.36f, 0f);
        }

        LifeCheck();
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

    public void LifeCheck()
    {
        if (life <= 0)
        {
            SceneManager.LoadScene("Stage1");
        }
    }

    public void GetDamage()
    {
        Debug.Log("Gotcha");
        

        life -= 10f;

        //enemieAnimator = gameObject.GetComponent<Animator>();
        //enemieAnimator.runtimeAnimatorController = hitAnimation;
        //StartCoroutine(SwitchAnimator());
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.layer == 10)
        {
            GetDamage();

            rb = gameObject.GetComponent<Rigidbody2D>();
            if (animator.GetFloat("speed") > 0.01f && !animator.GetBool("IsJumping"))
            {
                rb.AddForce(-rb.velocity.normalized * 1600);    
            } else   
            {  
                rb.AddForce(-rb.velocity.normalized * 600);
            }
        }  
    }
}
