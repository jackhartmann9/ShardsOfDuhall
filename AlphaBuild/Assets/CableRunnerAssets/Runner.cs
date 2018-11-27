using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour {

    public Vector3 upperLane = new Vector3(-5, 3, 0);
    private int playerPosition = 0;
    public GameObject obstaclePrefab;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", 1, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y != 3)
        {
            transform.position = new Vector3(-5, transform.position.y +3, 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y != -3)
        {
            transform.position = new Vector3(-5, transform.position.y -3, 0);

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this);
    }

    void Spawn()
    {
        int lane = 0;
        int laneDecider = Random.Range(0, 4);
        if (laneDecider == 1)
        {
            lane = 0;
        }
        else if (laneDecider == 2)
        {
            lane = 3;
        }
        else if (laneDecider == 3)
        {
            lane = -3;
        }
        // Instantiate the food at (x, y)
        GameObject instantiateObstacle = Instantiate(obstaclePrefab) as GameObject;
        instantiateObstacle.transform.position = new Vector3(8, lane, 1);
    }
}
