using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

    // Variable Initialization 
    Rigidbody2D bossRigidBody2D;
    // Sets the distance to move the object
    // WE WILL LATER SET THIS TO UNTIL COLLIDE WITH BOUNDS
    public int UnitsToMove = 5;
    // Sets the speed of the object 
    public float speed = 500;
    // Stores the starting x cordinate of our object
    private float startPos;
    // Stores the x cordinate of the destination of our object 
    private float endPos;
    // Checks what direction the object is facing
    public bool isFacingRight;
    // Checks what direction the object is moving. Default is moving to the right 
    public bool moveRight = true;

    float timer;
    int waitingTime = 2;

    // Health
    int health = 10;
    //UI 
    public Text bossHealth; 


    /*
    *   Awake vs Start? 
    *   Awake will be called on this object as soon as the game starts. 
    *   Start will be called as soon as the object is enabled. If you later disable and 
    *   object and re-enable it, Start will not be called again. (Both functions are called at most once.) 
    */
    public void Awake()
    {
        bossHealth.text = "Boss Health: " + health.ToString();
        bossRigidBody2D = GetComponent<Rigidbody2D>();
        // Gets current X cord 
        startPos = transform.position.x;
        // Gets X cord after moving 
        endPos = startPos + UnitsToMove;
        isFacingRight = transform.localScale.x > 0;

    }

    // Update is called once per frame
    void Update () {

        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            //Action
            Debug.Log("Reset Timer.");
            timer = 0;
        }

        // Object is moving to the right
        if (moveRight == true ){
            bossRigidBody2D.AddForce(Vector2.right * speed * Time.deltaTime);
            // If the object is facing left we need to flip it
            if (isFacingRight == false){
                Flip();
            }
        }
        if(bossRigidBody2D.position.x >= endPos){
            moveRight = false;

        }

        // Object is movign to the left
        if(moveRight == false){
            bossRigidBody2D.AddForce(-Vector2.right * speed * Time.deltaTime);
            // If the object is facing right we need to flip it 
            if(isFacingRight == true){
                Flip();
            }
        }

        // If starting obj start pos is <= that means we are to the right of our start pos. 
        if (bossRigidBody2D.position.x <= startPos){
            moveRight = true;
        }

        
    }

   

    // Collision 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            if(health > 0)
            {
                health = health - 1;
                Destroy(collision.gameObject);
              
            }
            else
            {
                Debug.Log("Boss Destroyed.");
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            bossHealth.text = "Boss Health: " + health.ToString();
           
        }
    }

    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        isFacingRight = transform.localScale.x > 0;
    }
}