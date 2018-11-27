﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int objectSpeed = 5;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * objectSpeed * Time.deltaTime);

        if (transform.position.x <= -8){
            Destroy(this.gameObject);
        }


    }

}
