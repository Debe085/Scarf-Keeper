using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemie : MonoBehaviour
{

    //Enemie properties
    public float life = 100f;
    private Animator enemieAnimator;
    public RuntimeAnimatorController hitAnimation;
    public RuntimeAnimatorController idleAnimation;

    //Patrol properties
    public float walkSpeed = -1;
    bool mustPatrol;
    bool mustFlip;
    public Rigidbody2D rb;
    public Transform groundCheck;

    public LayerMask groundLayer;

    private void Start() 
    {
        mustPatrol = true;    
    }

    //Functions
    private void Update()
    {
        LifeCheck();
    }

    private void FixedUpdate() 
    {
            if (mustPatrol)
            {
                mustFlip = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

                AIPatrol();
            }
    }

    public void AIPatrol()
    {
        if (mustFlip)
        {
            Flip();
        }
        
        rb.velocity = new Vector2(-walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    public void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        //transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
    }

    public void GetDamage()
    {
        life -= 50f;

        enemieAnimator = gameObject.GetComponent<Animator>();
        enemieAnimator.runtimeAnimatorController = hitAnimation;

        StartCoroutine(SwitchAnimator());
    }

    public IEnumerator SwitchAnimator()
    {
        yield return new WaitForSeconds(0.1f);
        
        enemieAnimator.runtimeAnimatorController = idleAnimation;    
        
        StopAllCoroutines();
    }

    public void LifeCheck()
    {
        if(life <= 0)
        {
            Destroy(gameObject);
        }    
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Bullet")
        {
            GetDamage();
        } else if(other.gameObject.tag == "Player")
        {
            AIPatrol();
        }
    }
}
