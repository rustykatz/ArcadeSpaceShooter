using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Shoot : MonoBehaviour {

    public Rigidbody2D Projectile;
    public float speed;
    public float force;


    private float bulletLife = 3.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // Basic Shooting Script
        /*
         * Every time player hits space bar, we create a projectile clone
         * Each clone is based off our Projectile Prefab which has tag: "bullet"
         * After spawning, it is destroyed after x time, to save memory
         * 
         */
        if(Input.GetKeyDown(KeyCode.Space)){
            Rigidbody2D clone;
            clone = Instantiate(Projectile, transform.position, Quaternion.identity) as Rigidbody2D;
            clone.velocity = transform.TransformDirection(Vector2.up * force);

            if(clone.gameObject.tag == "bullet"){
                Destroy(clone.gameObject, bulletLife);
            }


        }


           
		
	}
}
