using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {
  private int score = 0;
	private bool ate = false;
	private float speed = 0.03f;
	public Text scoreText;
  public Text timeText;
  public GameObject roundEndDisplay;
  private float timeLeft = 30.0f;
	public GameObject tailPrefab;
    Vector2 dir = Vector2.right;
	List<Transform> tail = new List<Transform>();


    void Start () {
        PlayerPrefs.SetInt("Score", 0);
        InvokeRepeating("Move", speed, speed);
        dir = Vector2.zero;
    }

    // Update is called once per frame
    void Update() {
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0f){
          EndGame();
        }
        timeText.text = (timeLeft).ToString("0");
        UpdateSpeed(timeLeft);
    // Move in a new Direction
	    if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
	        dir = Vector2.right;
	    else if (Input.GetKeyDown("s")|| Input.GetKeyDown("down"))
	        dir = -Vector2.up;
	    else if (Input.GetKeyDown("a")|| Input.GetKeyDown("left"))
	        dir = -Vector2.right;
	    else if (Input.GetKeyDown("w")|| Input.GetKeyDown("up"))
	        dir = Vector2.up;
	}

   private void UpdateSpeed(float timeLeft){
     float time = 30.0f - timeLeft;
     speed += time/15f * 0.05f;
   }
   void Move() {
    Vector2 v = transform.position;

    transform.Translate(dir);

    if (ate) {
        score++;
        scoreText.text = score.ToString();
        GameObject g =(GameObject)Instantiate(tailPrefab,
                                              v,
                                              Quaternion.identity);

        tail.Insert(0, g.transform);

        GameObject g1 =(GameObject)Instantiate(tailPrefab,
                                              v,
                                              Quaternion.identity);


        tail.Insert(0, g1.transform);
        GameObject g2 =(GameObject)Instantiate(tailPrefab,
                                              v,
                                              Quaternion.identity);

        tail.Insert(0, g2.transform);
        ate = false;
        speed = speed * .7f;
    }
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
        if (coll.gameObject.tag == "Food") {
            ate = true;
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "AvoidThis") {
            score -= 3;
            Destroy(coll.gameObject);
            scoreText.text = score.ToString();
        }

        if (coll.gameObject.tag == "EndGame") {
        	Debug.Log("Dead");
          EndGame();

        }
	}

void EndGame(){
    Debug.Log("END");
    PlayerPrefs.SetInt("Score", score);
    //roundEndDisplay.SetActive(true);
    //yield return new WaitForSeconds(3);
    Destroy(this);
    SceneManager.LoadScene("MainMenu");
  }


}
