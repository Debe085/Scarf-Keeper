using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller;

    public float speed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        crouch = false;
    }
}
