﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PrevScore : MonoBehaviour {
	private int score;
	public Text scoreText;
	// Use this for initialization
	void Start () {
		score = 0;

	  Debug.Log("start score = " + score);
		//score = PlayerPrefs.GetInt("score");
		//scoreText.text = score.ToString();

	}

	// Update is called once per frame
	void Update () {
		Debug.Log("curr score = " + score);
		score = PlayerPrefs.GetInt("Score");
		scoreText.text = score.ToString();

	  Debug.Log("curr score = " + score);
	}
}
