using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_move : MonoBehaviour {
    public float speed = 3.0f;
    bool speedboost = false; 
   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (speedboost == false)
        {
            speed = 3.0f;
        }else {
            speed = 5.0f;
        }

        // Speedboost

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedboost = true;
        }else{
            speedboost = false; 
        }

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