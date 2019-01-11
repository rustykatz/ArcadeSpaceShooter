using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour {
    public Rigidbody2D enemy_1;
    public Rigidbody2D enemy_2;

    public float spawnFreq_1 = 1.0f;
    public float spawnFreq_2 = 0.8f;

    public float maxS = -6.0f;
    public float minS = 6.0f;

    float diff_1 = 1f;
    float diff_2 = 0.8f; 
    float diffTimer = 0; 

   // public float speed;
  

    // Use this for initialization
    void Start () {
        // InvokeRepeating: (fxn to invoke, start time, everytime after start) 
     
        InvokeRepeating("SpawnEnemy_1", 1.0f, diff_1);
        InvokeRepeating("SpawnEnemy_2", 3.0f, diff_2);
        
	}
	
	// Update is called once per frame
    void Update () {
        Difficulty();
    }

    void SpawnEnemy_1(){
        Rigidbody2D enemy_clone_1;
        Vector2 spawnPosition = new Vector2(Random.Range(minS, maxS), transform.position.y);
      
        enemy_clone_1 = Instantiate(enemy_1, spawnPosition, transform.rotation * Quaternion.Euler(0,0,0)) as Rigidbody2D;
        //enemy_clone_1.velocity = transform.TransformDirection(Vector2.up * speed);

    }
    void SpawnEnemy_2()
    {
        Rigidbody2D enemy_clone_2;
        Vector2 spawnPosition = new Vector2(Random.Range(minS, maxS), transform.position.y);

        enemy_clone_2 = Instantiate(enemy_2, spawnPosition, transform.rotation * Quaternion.Euler(0, 0, 0)) as Rigidbody2D;
        //enemy_clone_2.velocity = transform.TransformDirection(Vector2.up * speed);

    }

    void Difficulty()
    {
        diffTimer += Time.deltaTime;
       
        if( diffTimer > 10)
        {
            Debug.Log("Increase difficulty");
            diff_1 -= 0.5f;
            diff_2 -= 0.5f;
            diffTimer = 0;
            Debug.Log(diff_1);
            Debug.Log(diff_2);
        }
       
    }
}