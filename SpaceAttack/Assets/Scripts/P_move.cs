using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class P_move : MonoBehaviour {
    // Ship speed
    public float speed = 3.0f;

    //Game State
    bool gameRunning = false; 

    

    public Vector2 screenBounds;
    public float objWidth;
    public float objHeight;

    //bool speedboost = false; 

    // Weapon code
    public Rigidbody2D Current_Projectile;
    public Rigidbody2D Projectile_1;
    public Rigidbody2D Projectile_2;
    public Rigidbody2D Projectile_3;
    private int curr_weapon;
    private float bullet_life = 3.0f;
    public float wp_force;

    //lives_remaining 
    int lives_remaining;
    string death_screen = "DeathLevel";
    
    // Use this for initialization
    void Start () {
        

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        curr_weapon = 1;
        lives_remaining = 3; 

	}
	
	// Update is called once per frame
	void Update () {


        KeepScreenBounds();
        Movement();
        Weapon();
       
    }

    void Movement(){

        //if (speedboost == false)
        //{
        //    speed = 3.0f;
        //}else {
        //    speed = 5.0f;
        //}

        //// Speedboost

        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    speedboost = true;
        //}else{
        //    speedboost = false; 
        //
        // Basic Player Movement

        if (Input.GetKey(KeyCode.W)){

            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)){
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)){
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

    }

    void Weapon(){
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            curr_weapon = 1;
            Current_Projectile = Projectile_1;
            Debug.Log("Weapon switch: 1.");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            curr_weapon = 2;
            Current_Projectile = Projectile_2;
            Debug.Log("Weapon switch: 2.");

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            curr_weapon = 3;
            Current_Projectile = Projectile_3;
            Debug.Log("Weapon switch: 3.");

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D clone;
            clone = Instantiate(Current_Projectile, transform.position, Quaternion.identity) as Rigidbody2D;
            clone.velocity = transform.TransformDirection(Vector2.up * wp_force);

            if (clone.gameObject.tag == "bullet" && clone.gameObject != null)
            {
                Destroy(clone.gameObject, bullet_life);
            }


        }

    }

    void KeepScreenBounds(){
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objWidth,screenBounds.x * -1-objWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objHeight, screenBounds.y *-1-objHeight);
        transform.position = viewPos;
      
    }

    // Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("Player has collided into enemy.");
            Destroy(gameObject);
            Destroy(collision.gameObject);
            chk_death();
            lives_remaining = lives_remaining - 1;

            Debug.Log("lives_remaining remaining: " + lives_remaining.ToString());

        }
    }

    void chk_death(){
        if(lives_remaining == 0){

            Debug.Log("Score Paused.");
            Debug.Log("Transitioning to death_screen");
            SceneManager.LoadScene(death_screen);

        }
        
    }

}