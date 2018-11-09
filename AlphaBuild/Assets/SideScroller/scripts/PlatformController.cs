using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlatformController : MonoBehaviour {


    public bool facingRight = true;
    public bool jump = false;
    public float speed = 10f;
    public float jumpForce = 1200f;
    public float maxSpeed = 15f;
    bool isMovedLeft = false;
    bool isMovedRight = false;
    private float timeLeft = 60.0f;

    private bool grounded = false;
    //private Animator anim;
    private Rigidbody2D rb2d;


    // Use this for initialization
    void Awake ()
    {
        //anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update ()
    {
      transform.eulerAngles = new Vector3 (0, 0, 0);
//        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        timeLeft -= Time.deltaTime;
        float newSpeed = 9f + (60f - timeLeft) / 4f;
        Debug.Log("Speed = " + newSpeed);
        if(newSpeed > speed){
          speed = newSpeed;
        }
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("grounded and jumping");
            //jump = true;
            rb2d.AddForce(new Vector2(0f, jumpForce));
        }
        if (Input.GetKeyDown("a"))
        {
            isMovedLeft = true;
            isMovedRight = false;
        } else if (Input.GetKeyDown("d"))
        {
            isMovedRight = true;
            isMovedLeft = false;
        } else
        {
            //isMovedLeft = false;
            //isMovedRight = false;
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
//Used for physics concepts, but adapted to current game

    void FixedUpdate()
    {

        if (jump)
        {
            //rb2d.AddForce(new Vector2(0f, jumpForce));
            //jump = false;
        }
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theDirection = transform.localScale;
        theDirection.x *= -1;
        transform.localScale = theDirection;
    }
}
