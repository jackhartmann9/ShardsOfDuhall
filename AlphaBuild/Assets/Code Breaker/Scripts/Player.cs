using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public KeyCode rotateL;
    public KeyCode rotateR;
    public KeyCode moveU;
    public KeyCode fire;
    public float moveMod;
    public float rotateMod;
    public float bulletSpeed;
    public float screenTop;
    public float screenBottom;
    public float screenRight;
    public float screenLeft;

    private int score;
    private int timeRemaining;
    public Text scoreLabel;
    public Text finalScoreLabel;
    public Text timeLabel;

    public GameObject bullet;
    public GameObject gameOverPanel;

    private void Start()
    {
        score = 0;
        timeRemaining = 30;
        StartCoroutine(Countdown());
    }

    void Update()
    {

        //Create Bullet if fired
        if (Input.GetKeyDown(fire))
        {
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed);
            Destroy(newBullet, 6.0f);
        }

        //Screen wrapping
        Vector2 newPos = transform.position;
        if(transform.position.y > screenTop)
        {
            newPos.y = screenBottom;
        }
        if (transform.position.y < screenBottom)
        {
            newPos.y = screenTop;
        }
        if (transform.position.x > screenRight)
        {
            newPos.x = screenLeft;
        }
        if (transform.position.x < screenLeft)
        {
            newPos.x = screenRight;
        }
        transform.position = newPos;

        scoreLabel.text = "Score: " + score;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(moveU))
        {
           rb.AddRelativeForce(Vector2.up * moveMod);
        }
        if (Input.GetKey(rotateL))
        {
            rb.AddTorque(rotateMod);
        }
        if (Input.GetKey(rotateR))
        {
            rb.AddTorque(-rotateMod);
        }
    }

    IEnumerator Countdown()
    {
        for (int i = 0; i < 30; i++)
        {
            timeRemaining--;
            yield return new WaitForSeconds(1);
            timeLabel.text = "Time Remaining: " + timeRemaining;
            if (timeRemaining == 0)
            {
                GameOver();
            }
        }
    }

    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(3);
        PlayerPrefs.SetInt("Score", score);
        Destroy(this);
        SceneManager.LoadScene("MainMenu");
    }

    void ScorePoints(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    void GameOver()
    {
        finalScoreLabel.text = "Final Score: " + score;
        gameOverPanel.SetActive(true);
        StartCoroutine(TimeOut());
    }

}
