using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class P_move : MonoBehaviour {
    public float speed = 3.0f;

    public Vector2 screenBounds;
    public float objWidth;
    public float objHeight;
   //bool speedboost = false; 
   

	// Use this for initialization
	void Start () {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
	}
	
	// Update is called once per frame
	void Update () {


        KeepScreenBounds();
        Movement();

       
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
        }
    }
}