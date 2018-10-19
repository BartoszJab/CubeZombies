using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public PlayerHealth playerHealth;
    public GameObject Enemy;
    public float spawnTime = 2f;
    public Transform[] spawnPoints;


	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
                  //(thing to spawn,position of the thing, rotation the thing should have)
        Instantiate(Enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        
        
    }

}
