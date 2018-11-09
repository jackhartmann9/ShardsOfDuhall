using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int objectSpeed = 5;
    public GameObject obstaclePrefab;
    private object collidedWith;

    // Use this for initialization
    void Start () {
       
        InvokeRepeating("Spawn", 1, 0);

    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * objectSpeed * Time.deltaTime);

        if (transform.position.x <= -8){
            Destroy(this.gameObject);
        }


    }

    void Spawn()
    {
        int lane = 0;
        int laneDecider = Random.Range(0, 4);
        if(laneDecider == 1){
            lane = 0;
        }
        else if(laneDecider == 2){
            lane = 3;
        }
        else if(laneDecider == 3){
            lane = -3;
        }
        // Instantiate the food at (x, y)
        GameObject instantiateObstacle = Instantiate(obstaclePrefab) as GameObject;
        instantiateObstacle.transform.position = new Vector3(8, lane ,1);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(coll.gameObject);
        }
    }
}
