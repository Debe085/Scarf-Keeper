using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool status = false; //status = false --> door closed [---] status = true --> door opened
     
    private bool insertKey = false;

    private Player player;

    public Sprite doorOpened;

    // Update is called once per frame
    void Update()
    {
        CheckStatus();
        if (Input.GetButtonDown("Interact"))
        {
            insertKey = true;
        }
    }

    void CheckStatus()
    {
        if (status)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = doorOpened;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        //if (other.gameObject.tag == "Player"){}
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().OpenDoor(insertKey);
        }
    }
}
