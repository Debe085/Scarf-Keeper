using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : MonoBehaviour
{
    [SerializeField] CircleCollider2D orangeCollider;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.time * 3) * 0.002f, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
      if(other.gameObject.tag == "Player")
      {
        other.gameObject.GetComponent<Player>().Heal(80);
      }

        Destroy(gameObject);
    }
}
