using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public LayerMask enemieLayer;
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject enemie;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        Destroy(gameObject);

        try
        {
            if(hitinfo.gameObject.layer == 10)
            {
                hitinfo.gameObject.GetComponent<Enemie>().GetDamage();
            }
                
        }
        catch
        {
        }
    }

}
