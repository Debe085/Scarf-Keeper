using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.time * 3) * 0.002f, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().keys = 1;
        }

        Destroy(gameObject);
    }
}
