using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public float Speed;
    public float live = 10;

    private Rigidbody rb;
    private Vector3 position;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        position = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position == position)
        {
           position =new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0); 
        }


        rb.position = Vector3.MoveTowards(rb.position, position, Speed*Time.deltaTime);
        



    }

    public void Hit(int DMG)
    {
        live -= DMG;

        if (live <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(5);

        }
    }

}
