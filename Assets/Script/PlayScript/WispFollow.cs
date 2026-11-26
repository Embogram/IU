using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispFollow : MonoBehaviour
{
    public float Speed;
    public Transform WispWay;
    
    private Vector3 playerPosition;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (rb.position != WispWay.position)
        {
            rb.position = Vector3.MoveTowards(rb.position, WispWay.position, Speed * Time.deltaTime);
        }

        //playerPosition = Wisp.transform.position;

        Vector3 targetVector = playerPosition - transform.position;

        //Quaternion targetRotation = Quaternion.LookRotation(targetVector);

        //GetComponent<Rigidbody>().velocity = targetVector.normalized * Speed;


    }
}
