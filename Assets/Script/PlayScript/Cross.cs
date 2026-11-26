using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Cross : MonoBehaviour
{

    public GameObject Crosshair;
    
    public GameObject player; // is Wisp
    public GameObject BulletPrefab;
    public GameObject BulletStart;

    public float BulletSpeed = 60.0f;

    private Vector3 target;

    private float laserTime = 1;
    private float fireRate = 1;



    void Start()
    {
        Cursor.visible = false;

    }


    void Update()
    {
        target = transform.GetComponent<Camera>()
            .ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        Crosshair.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);


        if (laserTime < fireRate)
        {
            laserTime += Time.deltaTime;
        }
        else if (Input.GetMouseButton(0))
        {

            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction, rotationZ);
            laserTime = 0;

        }

        void fireBullet(Vector2 direction, float rotationZ)
        {
            GameObject b = Instantiate(BulletPrefab) as GameObject;
            b.transform.position = BulletStart.transform.position;
            b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            b.GetComponent<Rigidbody>().linearVelocity = direction * BulletSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

    }
}