using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI keysText;
    public float keys = 0f;
    public float life = 120f;
    private Rigidbody2D rb;
    public CharacterController2D controller;
    public Animator animator;

    public Door door;

    public Transform firePoint;

    public float speed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Update()
    {
        CheckKeys();
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            speed = 30f;
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
        speed = 40f;
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

    public void GetDamage(float damage)
    {
        life -= damage;

        //enemieAnimator = gameObject.GetComponent<Animator>();
        //enemieAnimator.runtimeAnimatorController = hitAnimation;
        //StartCoroutine(SwitchAnimator());
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.layer == 10)
        {
            GetDamage(10);

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

    public void OpenDoor(bool open)
    {
        if(open && keys >= 1)
        {
            door.status = true;
            keys -= 1;
        }
    }

    void CheckKeys()
    {
        keysText.text = "" + keys;
    }

    public void Heal(float heal)
    {
        if ((gameObject.GetComponent<Player>().life + heal) > 120f)
        {
            life = 120f;
        }
        else
        {
            life += 80f;
        }
    }
}
