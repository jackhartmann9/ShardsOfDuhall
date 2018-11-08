using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Vector3 upperLane = new Vector3(-5, 3, 0);
    private int playerPosition = 0;

    // Use this for initialization
    void Start () {
		
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
}
