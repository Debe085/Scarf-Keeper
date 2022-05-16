using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemie : MonoBehaviour
{
    //Enemie properties
    public float life = 100f;
    [SerializeField] Transform headCheck;
    private CircleCollider2D colliderEnemie;

    //Bullet properties

    public Bullet bullet;

    //Player properties
    [SerializeField] Rigidbody2D playerBody;
    public Animator playerAnimator;
    [SerializeField] Transform playerTranform;

    //Staff
    [SerializeField] LayerMask playerLayer;
    [SerializeField] LayerMask bulletLayer;
    const float headRadius = .2f;

    void FixedUpdate()
    {
        colliderEnemie = gameObject.GetComponent<CircleCollider2D>();

        Collider2D[] colliderPlayer = Physics2D.OverlapCircleAll(headCheck.position, headRadius, playerLayer);
		for (int i = 0; i < colliderPlayer.Length; i++)
		{
			if (colliderPlayer[i].gameObject != gameObject)
			{
                life -= 100;
                playerBody.AddForce(new Vector2(0f, 800f));
                playerAnimator.SetBool("IsJumping", true);
			}
		}
        
        LifeCheck();
    }

    public void GetDamage()
    {
        life -= 50f;
    }
    public void LifeCheck()
    {
        if(life <= 0)
        {
            Destroy(gameObject);
        }    
    }
}
