using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Shoot : MonoBehaviour {

    // Different bullet types 
    public Rigidbody2D Current_Projectile; 
    public Rigidbody2D Projectile_1;
    public Rigidbody2D Projectile_2;
    public Rigidbody2D Projectile_3;

    private int weapon;

    public float speed;
    public float force;


    private float bulletLife = 3.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // Switches weapons when user presses keys 1-4  
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            weapon = 1;
            Current_Projectile = Projectile_1;
            Debug.Log("Weapon switch: 1.");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            weapon = 2;
            Current_Projectile = Projectile_2;
            Debug.Log("Weapon switch: 2.");

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)){
            weapon = 3;
            Current_Projectile = Projectile_3;
            Debug.Log("Weapon switch: 3.");

        }
      

       
        // Basic Shooting Script
        /*
         * Every time player hits space bar, we create a projectile clone
         * Each clone is based off our Projectile Prefab which has tag: "bullet"
         * After spawning, it is destroyed after x time, to save memory
         * 
         */
        if (Input.GetKeyDown(KeyCode.Space)){
            Rigidbody2D clone;
          
            clone = Instantiate(Current_Projectile, transform.position, Quaternion.identity) as Rigidbody2D;

            clone.velocity = transform.TransformDirection(Vector2.up * force);

            if(clone.gameObject.tag == "bullet" && clone.gameObject != null ){
                Destroy(clone.gameObject, bulletLife);
            }


        }


	}

   
}
