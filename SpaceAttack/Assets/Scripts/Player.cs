﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour {
    // Ship speed
    public float speed = 3.0f;

    //Game State
    int Score;
    int HS;
    public Text HSS;
    bool gameRunning = false;
    public Text Score_Txt;
    private float Timer;

    
    //Screen bounds
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
    public float wp_force = 6.0f;

    //lives_remaining 
    int lives_remaining;
    string death_screen = "DeathScreen";
    
    // Use this for initialization
    void Start () {
        
        
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        gameRunning = true;
        curr_weapon = 1;
        lives_remaining = 3;
        Score = 0;
        HSS.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
     

	}
	
	// Update is called once per frame
	void Update () {

        KeepScreenBounds();
        Movement();
        Weapon();
        Game_score();
       
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

    // Player weapon switches
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

    // Screen Bounds
    void KeepScreenBounds(){
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objWidth,screenBounds.x * -1 - objWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objHeight, screenBounds.y *-1 - objHeight);
        transform.position = viewPos;
      
    }

    // Collision w/ Enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("Player has collided into enemy.");
           
            
            Destroy(collision.gameObject);
           
            lives_remaining = lives_remaining - 1;
            if( lives_remaining == 0)
            {
                On_death();
                Destroy(gameObject);
            }
            

            Debug.Log("lives_remaining remaining: " + lives_remaining.ToString());

        }

    }

    // Check if player is dead
    void On_death(){
        gameRunning = false; 
        Debug.Log("Updating highscore if necessary.");

        //Saves the Current game score
        PlayerPrefs.SetInt("LastScore", Score);
        
        //GameObject.FindGameObjectWithTag.        
        // Updates highscore if necessary
        if (Score > PlayerPrefs.GetInt("HighScore", 0)){
            PlayerPrefs.SetInt("HighScore", Score);
            HSS.text = Score.ToString();
            Debug.Log("New HighScore set. ");

        }
        Debug.Log("Transitioning to death_screen");
        SceneManager.LoadScene(death_screen);
    }
 

    // Update game score
    void Game_score()
    {
        if (gameRunning == true)
        {
            Timer += Time.deltaTime;
            Score = (int)(Timer );
            Score_Txt.text = "Score: " + Score.ToString();
        }

       
    }


}