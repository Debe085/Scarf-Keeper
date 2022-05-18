using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public LayerMask enemieLayer;
    public Rigidbody2D rb;
    public GameObject enemie;

    void Start()
    {
        rb.velocity = transform.right * speed;

        StartCoroutine(BulletLife());
    }

    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        Destroy(gameObject);
    }

    public IEnumerator BulletLife()
    {
        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);

        StopAllCoroutines();
    }

}
