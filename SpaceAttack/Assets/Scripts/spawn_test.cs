using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_test : MonoBehaviour
{
    public GameObject enemy_1;
    public float minS;
    public float maxS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawn_enemy()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(minS, maxS), transform.position.y);
        Instantiate(enemy_1, spawnPosition, Quaternion.identity);
    }
}
