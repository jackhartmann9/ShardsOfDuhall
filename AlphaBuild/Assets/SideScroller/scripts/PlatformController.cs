//Platform/SideScroller game for Shards of Duhall
//Created by Osis Games
//Code Owner: Jack Hartmann

using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlatformController : MonoBehaviour {

    private int score = 0;
    private bool facingRight = true;
    //Start to not allow double jumping
    private bool jump = false;
    private float speed = 8f;
    private float jumpForce = 1200f;
    //speed scales with time up to maxSpeed
    private float maxSpeed = 15f;
    private float scoreMod = 10;
    bool isMovedLeft = false;
    bool isMovedRight = false;
    //Text pieces of the canvas to display score and Time
  	public Text scoreText;
    public Text timeText;
    private float timeLeft = 30.0f;
    //Grounded was to check for double jump mechanics
    private bool grounded = false;
    private Rigidbody2D rb2d;


    // Use this for initialization
    void Awake ()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update ()
    {

      scoreText.text = "Score: " + score.ToString();
      //Keeps the angle of the player from rotating on collision.
      transform.eulerAngles = new Vector3 (0, 0, 0);

      //Modify the time to display correctly
      timeLeft -= Time.deltaTime;
      if(timeLeft < 0){
        PlayerPrefs.SetInt("Score", (int)score);
          Destroy(this);
          SceneManager.LoadScene("MainMenu");
      }
      timeText.text = "Time: " + (timeLeft).ToString("0");
      //grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        float newSpeed = 9f + (60f - timeLeft) / 4f;
        score = (int)(Math.Floor(transform.position.x/scoreMod));
        if(newSpeed > speed){
          speed = newSpeed;
        }

        //space to jump
        if (Input.GetKeyDown("space"))
        {
            //jump = true;
            rb2d.AddForce(new Vector2(0f, jumpForce));
        }

        //set direction to left
        if (Input.GetKey("a"))
        {
            isMovedLeft = true;
            isMovedRight = false;
        }
        //Set direction to right
        else if (Input.GetKey("d"))
        {
            isMovedRight = true;
            isMovedLeft = false;
        } else
        {
            isMovedLeft = false;
            isMovedRight = false;
        }
        if (isMovedRight)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        } else if (isMovedLeft)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
      }


//Physics from https://unity3d.com/learn/tutorials/topics/2d-game-creation/creating-basic-platformer-game
//used for double jump mechanic
//Used for physics concepts, but adapted to current game

    void FixedUpdate()
    {

        if (jump)
        {

            //rb2d.AddForce(new Vector2(0f, jumpForce));
            //jump = false;
        }
    }

    //End the double jump mechanic and Physics concepts


    void OnCollisionEnter2D(Collision2D coll) {
            Debug.Log("Entered on > " + coll.gameObject.tag);
            //If they hit a fire wall then score is changed
            //load the main menu scene
            if (coll.gameObject.tag == "Bad") {
              PlayerPrefs.SetInt("Score", (int)score);
                Destroy(this);
                SceneManager.LoadScene("MainMenu");
                // ToDo 'You lose' screen
            }
    	}


}
