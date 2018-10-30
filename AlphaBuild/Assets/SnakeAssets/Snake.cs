using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {
    private int score = 0;
	bool ate = false;
	private float speed = 0.02f;
	public Text scoreText;
    public Text timeText;
    private float timeLeft = 60.0f;
	public GameObject tailPrefab;
    Vector2 dir = Vector2.right;
    // Keep Track of Tail
	List<Transform> tail = new List<Transform>();

    // Use this for initialization
    void Start () {
        // Move the Snake every 300ms
        InvokeRepeating("Move", speed, speed);    
    }
    
    // Update is called once per frame
    void Update() {
        timeLeft -= Time.deltaTime;
        timeText.text = (timeLeft).ToString("0");
    // Move in a new Direction?
	    if (Input.GetKey(KeyCode.RightArrow))
	        dir = Vector2.right;
	    else if (Input.GetKey(KeyCode.DownArrow))
	        dir = -Vector2.up;    // '-up' means 'down'
	    else if (Input.GetKey(KeyCode.LeftArrow))
	        dir = -Vector2.right; // '-right' means 'left'
	    else if (Input.GetKey(KeyCode.UpArrow))
	        dir = Vector2.up;
	}
    
   void Move() {
    // Save current position (gap will be here)
    Vector2 v = transform.position;

    // Move head into new direction (now there is a gap)
    transform.Translate(dir);

    // Ate something? Then insert new Element into gap
    if (ate) {
        score++;
        scoreText.text = score.ToString();
        // Load Prefab into the world
        GameObject g =(GameObject)Instantiate(tailPrefab,
                                              v,
                                              Quaternion.identity);

        // Keep track of it in our tail list
        tail.Insert(0, g.transform);

        GameObject g1 =(GameObject)Instantiate(tailPrefab,
                                              v,
                                              Quaternion.identity);

        // Keep track of it in our tail list
        tail.Insert(0, g1.transform);

        GameObject g2 =(GameObject)Instantiate(tailPrefab,
                                              v,
                                              Quaternion.identity);

        // Keep track of it in our tail list
        tail.Insert(0, g2.transform);

        // Reset the flag
        ate = false;
        speed = speed * .7f;
    }
    // Do we have a Tail?
    else if (tail.Count > 0) {
        // Move last Tail Element to where the Head was
        tail.Last().position = v;

        // Add to front of list, remove from the back
        tail.Insert(0, tail.Last());
        tail.RemoveAt(tail.Count-1);
    }
}

    void OnTriggerEnter2D(Collider2D coll) {
        // Food?
        if (coll.name.StartsWith("FoodPrefab")) {
            // Get longer in next Move call
            ate = true;
            
            // Remove the Food
            Destroy(coll.gameObject);
        }
        // Collided with Tail or Border
        if (coll.gameObject.tag == "EndGame") {
        	Debug.Log("Dead");
            Destroy(this);
            // ToDo 'You lose' screen
        }
	}


}