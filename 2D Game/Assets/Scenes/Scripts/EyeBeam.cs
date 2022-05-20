using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EyeBeam : MonoBehaviour
{
    public Transform firePoint;
    private Animator playerAnimator;
    public AnimationClip playerShooting;
    public float magazine = 6f;
    public float reload = 3f;
    public GameObject bulletPrefab;

    void Update()
    {
        playerAnimator = gameObject.GetComponent<Animator>();

        if (Input.GetButtonDown("Fire1") && magazine > 0)
        {
            Shoot();
            
            magazine -= 1;

            StartCoroutine(FireRate());
        } 

        if(Input.GetButtonDown("Reload"))
        {
            magazine = -1f;
            
            StartCoroutine(Recharge());
        }
    }

    void Shoot()
    {
        playerAnimator.SetBool("IsShooting", true);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public IEnumerator Recharge()
    {
        yield return new WaitForSeconds(reload);

        magazine = 6f;   

        StopAllCoroutines();
    }

    public IEnumerator FireRate()
    {
        yield return new WaitForSeconds(0.5f);

        playerAnimator.SetBool("IsShooting", false);

        StopAllCoroutines();
    }
}
