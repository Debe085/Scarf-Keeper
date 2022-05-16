using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemie : MonoBehaviour
{
    [SerializeField] float life = 100f;
    [SerializeField] Transform headCheck;

    [SerializeField] Rigidbody2D playerBody;
    public Animator playerAnimator;
    [SerializeField] Transform playerTranform;
    [SerializeField] LayerMask playerLayer;
    const float headRadius = .2f;

    void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(headCheck.position, headRadius, playerLayer);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
                life -= 100;
                playerBody.AddForce(new Vector2(0f, 800f));
                playerAnimator.SetBool("IsJumping", true);
			}
		}

        LifeCheck();
    }

    void LifeCheck()
    {
        if(life <= 0)
        {
            Destroy(gameObject);
        }    
    }
}
