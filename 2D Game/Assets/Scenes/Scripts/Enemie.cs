using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemie : MonoBehaviour
{
    public float life = 100f;
    
    [SerializeField] Transform headCheck;

    const float headRadius = .2f;

    private CircleCollider2D colliderEnemie;

    private Animator enemieAnimator;

    public RuntimeAnimatorController hitAnimation;

    public RuntimeAnimatorController idleAnimation;

    void Update() => LifeCheck();

    //The player takes damage and change the animation to "hitAnimation" which is the animation for the hit player
    public void GetDamage()
    {
        life -= 50f;

        enemieAnimator = gameObject.GetComponent<Animator>();
        enemieAnimator.runtimeAnimatorController = hitAnimation;

        StartCoroutine(SwitchAnimator());
    }

    //SwitchAnimator takes a little pause between the hit Animation and the idle Animation;
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
        }
    }
}
