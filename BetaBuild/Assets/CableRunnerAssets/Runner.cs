using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Runner : MonoBehaviour {

    public Vector3 upperLane = new Vector3(-5, 3, 0);
    private int playerPosition = 0;

    private int score = 0;

    public Text scoreText;
    public Text timeText;
    private float timeLeft = 30.0f;


	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score;
        timeLeft -= Time.deltaTime;
        timeText.text = "Time: " + (timeLeft).ToString("0");

        if(timeLeft <= 0){
            GameOver();
        }

        if (Input.GetKeyDown("w") && transform.position.y != 3)
        {
            transform.position = new Vector3(-5, transform.position.y +3, 0);
        }

        if (Input.GetKeyDown("s") && transform.position.y != -3)
        {
            transform.position = new Vector3(-5, transform.position.y -3, 0);

        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Point")
        {
            Destroy(coll.gameObject);
            score++;
        }
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(coll.gameObject);
            score = score - 3;
        }
    }

    void GameOver()
    {
        PlayerPrefs.SetInt("Score", score);
        Destroy(this);
        SceneManager.LoadScene("MainMenu");
    }
}
