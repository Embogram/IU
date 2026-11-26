using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    private Vector3 inputVector;
    private Vector3 moveVector;
    public float Speed = 2f;

    private void Update()
    {

        inputVector.x = Input.GetAxis("Horizontal");



        moveVector = inputVector;



        moveVector.x *= Speed;
        moveVector.y = GetComponent<Rigidbody>().linearVelocity.y;
        moveVector.z *= Speed;

        GetComponent<Rigidbody>().linearVelocity = moveVector;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag== "Enemy")
        {
            SceneManager.LoadScene(4);
        }
        
    }

}
