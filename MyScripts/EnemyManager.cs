using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 5f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.


    // Use this for initialization
    void Start () {

    
    InvokeRepeating("Spawn", spawnTime, spawnTime);




}

// Update is called once per frame
void Update () {
       


    }

    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);


        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
