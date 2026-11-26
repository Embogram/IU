using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;

    public float SpawnTime;
    public float Border = 14f;


    void Start()
    {
        InvokeRepeating("SpawnEnemy",SpawnTime, SpawnTime);

        
        
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        
        Vector3 SpawPosition = transform.position;

        SpawPosition.y = Random.Range(-Border,Border);

        Instantiate(Enemy, SpawPosition, Enemy.transform.rotation);
    }


}
