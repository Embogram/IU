using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Range(1, 10)] 
    
    Vector3 playerPosition;
    
    public float JumpVelocity;

    public float FallMulti = 2.5f;
    public float LowJumpMulti = 2f;

    public float Speed;
    private Vector3 inputVector;
    private Vector3 moveVector;

    Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {



        if (Input.GetButtonDown("Jump")&& isGrounded())
        {
            GetComponent<Rigidbody>().linearVelocity = Vector3.up * JumpVelocity;
        }

        if (rb.linearVelocity.y <= 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (FallMulti - 1) * Time.deltaTime;
        }
        else if (rb.linearVelocity.y >=0 && !Input.GetButton("Jump"))
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (LowJumpMulti - 1) * Time.deltaTime;
        }



        Debug.DrawRay(GetComponent<Rigidbody>().position, Vector3.down,Color.red);
        bool isGrounded()
        {
            return Physics.Raycast(GetComponent<Rigidbody>().position + Vector3.up, Vector3.down, 2f);

        }


    }




}
