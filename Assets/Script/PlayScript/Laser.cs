using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public float Speed;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        other.SendMessage("Hit",1,SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
