using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour {
    public Rigidbody2D enemy;
    public float speed;
  

    // Use this for initialization
    void Start () {
        // InvokeRepeating: (fxn to invoke, start time, everytime after start) 
        InvokeRepeating("SpawnEnemy", 1.0f, 0.8f);
	}
	
	// Update is called once per frame
    void Update () {}

    void SpawnEnemy(){
        Rigidbody2D enemy_clone;
        Vector2 spawnPosition = new Vector2(Random.Range(-6.5f, 6.5f), transform.position.y);
      
        enemy_clone = Instantiate(enemy, spawnPosition, transform.rotation * Quaternion.Euler(180,0,0)) as Rigidbody2D;
        enemy_clone.velocity = transform.TransformDirection(Vector2.up * speed);

    }
}