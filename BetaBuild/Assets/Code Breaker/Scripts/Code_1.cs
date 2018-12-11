using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code : MonoBehaviour {

    public Rigidbody2D rb;
    public float maxThrust;
    public float maxTorque;
    public float screenTop;
    public float screenBottom;
    public float screenRight;
    public float screenLeft;
    public int codeSize;
    public int points;

    public GameObject codeMedium;
    public GameObject codeSmall;
    public GameObject player;

	// Use this for initialization
	void Start () {
        //Give movement when created
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        rb.AddForce(thrust);
        rb.AddTorque(torque);

        player = GameObject.FindWithTag("Player");
	}

	// Update is called once per frame
	void Update () {
        //Screen wrapping
        Vector2 newPos = transform.position;
        if (transform.position.y > screenTop)
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
            //change asteroid size
            if (codeSize == 3)
            {
                Instantiate(codeMedium, transform.position, transform.rotation);
                Instantiate(codeMedium, transform.position, transform.rotation);
            }
            else if (codeSize == 2)
            {
                Instantiate(codeSmall, transform.position, transform.rotation);
                Instantiate(codeSmall, transform.position, transform.rotation);
            }
            //Give Points
            player.SendMessage("ScorePoints",points);

            Destroy(gameObject);
        }
    }
}
