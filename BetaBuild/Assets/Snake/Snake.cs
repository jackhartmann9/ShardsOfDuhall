/*Jack Hartmann
  OSIS Games
*/


﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {
  private int score = 0;
	private bool ate = false;
	private float speed = 0.03f;
	[SerializeField] private Text scoreText;
  [SerializeField] private Text timeText;
  [SerializeField] private GameObject roundEndDisplay;
  private float timeLeft = 30.0f;
	[SerializeField] private GameObject tailPrefab;
  Vector2 dir = Vector2.right;
	List<Transform> tail = new List<Transform>();


    void Start () {
        //Reset main menu player score;
        PlayerPrefs.SetInt("Score", 0);
        //Manage the movement of the snake head followed by the tail;
        InvokeRepeating("Move", speed, speed);
        dir = Vector2.zero;
    }

    // Update is called once per frame
    void Update() {
      //End Game if the time is over
      timeLeft -= Time.deltaTime;
      if(timeLeft < 0f){
        EndGame();
      }
      timeText.text = (timeLeft).ToString("0");
      UpdateSpeed(timeLeft);
	  }


   //Delegate Handling from Input Handler and Move Control
   public void MoveUp(){dir = Vector2.up;}
   public void MoveDown(){dir = -Vector2.up;}
   public void MoveLeft(){dir = -Vector2.right;}
   public void MoveRight(){dir = Vector2.right;}

   void Move() {
      Vector2 v = transform.position;
      transform.Translate(dir);
      //If the good item is eaten the score increases, and the tail grows;
      if (ate) {
          score++;
          scoreText.text = score.ToString();
          AddTail(3);
          ate = false;
      }
      //Move THe tail positions
      else if (tail.Count > 0) {
          // Move last Tail Element to where the Head was
          tail.Last().position = v;

          // Add to front of list, remove from the back
          tail.Insert(0, tail.Last());
          tail.RemoveAt(tail.Count-1);
      }
    }
    //Grow the tail of the snake
    private void AddTail(int numTails){
      Vector2 v = transform.position;
      transform.Translate(dir);
      for(int i = 0; i < numTails; i++){
        GameObject g =(GameObject)Instantiate(tailPrefab,
                                              v,
                                              Quaternion.identity);
        tail.Insert(0, g.transform);
      }
    }

  void OnTriggerEnter2D(Collider2D coll) {
          // Food Collision
          if (coll.gameObject.tag == "Food") {
              ate = true;
              Destroy(coll.gameObject);
          }

          //Collision with "bad food" that brings score down
          if (coll.gameObject.tag == "AvoidThis") {
              score -= 3;
              Destroy(coll.gameObject);
              scoreText.text = score.ToString();
          }

          //Collision with the boarders
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
