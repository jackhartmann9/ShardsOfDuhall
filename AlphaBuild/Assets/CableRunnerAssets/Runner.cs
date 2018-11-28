using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour {

    public Vector3 upperLane = new Vector3(-5, 3, 0);
    private int playerPosition = 0;
    public GameObject obstaclePrefab;
    public GameObject pointPrefab;
    private int enemyLane = 0;
    private int pointLane = 0;

    // Use this for initialization
    void Start () {
        InvokeRepeating("SpawnEnemy", 1, 1);
        InvokeRepeating("SpawnEnemy", 1, 3);
        InvokeRepeating("SpawnPoint", 1, 2);
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

    //Used by the enemy and the point prefabs to pick a lane to spawn in
    private int PickLane(){
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
        return lane;
    }

    void SpawnEnemy()
    {
        // Stops enemys from spawning in the same lane as a point
        enemyLane = PickLane();
        while (enemyLane == pointLane)
        {
            enemyLane = PickLane();
        }
        // Instantiate the obstacle at (x, y)
        GameObject instantiateObstacle = Instantiate(obstaclePrefab) as GameObject;
        instantiateObstacle.transform.position = new Vector3(8, enemyLane, 1);
    }

    void SpawnPoint()
    {
        // Stops points from spawning in the same lane as an enemy
        pointLane = PickLane();
        while (pointLane == enemyLane){
            pointLane = PickLane();
        }
        // Instantiate the obstacle at (x, y)
        GameObject instantiateObstacle = Instantiate(pointPrefab) as GameObject;
        instantiateObstacle.transform.position = new Vector3(8, pointLane, 1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Point")
        {
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(coll.gameObject);
        }
    }
}
