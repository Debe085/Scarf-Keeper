using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : MonoBehaviour
{
    [SerializeField] CircleCollider2D orangeCollider;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.time * 3) * 0.002f, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
      if (other.gameObject.tag == "Player")
      {
        if ((other.gameObject.GetComponent<Player>().life += 80f) > 100f)
        {
            other.gameObject.GetComponent<Player>().life = 120f;   
        } else 
        {
            other.gameObject.GetComponent<Player>().life += 80f;
        }
          
        Destroy(gameObject);
      }   
    }
}
