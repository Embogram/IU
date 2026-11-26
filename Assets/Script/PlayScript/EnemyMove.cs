using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMove : MonoBehaviour
{
    public GameObject Player;
    public float MoveSpeed = 4;
    public float Lives = 1;
    public float Rotation = 1;
    private Vector3 playerPosition;

    public void Start()
    {
        
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {

        playerPosition = Player.transform.position;

        Vector3 targetVector = playerPosition - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(targetVector);

        //transform.Rotation = Quaternion.Slerp(transform.Rotation, targetRotation, Rotation * Time.deltaTime);


        GetComponent<Rigidbody>().linearVelocity = targetVector.normalized * MoveSpeed;

        

    }

    public void Hit(int DMG)
    {
        Lives -= DMG;

        if (Lives <= 0)
        {
            Destroy(gameObject);
        }
    }
}
