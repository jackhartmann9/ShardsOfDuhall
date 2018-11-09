﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour {

    [SerializeField] private Text answerA;
    [SerializeField] private Text answerB;
    [SerializeField] private Text answerC;
    [SerializeField] private Text answerD;

    private AnswerData answerData;
    private GameController gameController;

	// Use this for initialization
	void Start () {
        gameController = FindObjectOfType<GameController>();
	}

    public void Setup(AnswerData data)
    {
        answerData = data;
        //Debug.Log("Answer Text: " + answerData);
        //answerA.text = answerData.answerText;
        //answerB.text = answerData.answerText;
        //answerC.text = answerData.answerText;
        //answerD.text = answerData.answerText;
    }
	
	public void HandleClick()
    {
        Debug.Log(gameController == null ? "Game Controller is Null" : "Game Controller is Working");
        Debug.Log(answerData == null ? "Answer Data is Null" : "Answer Data is Working");
        gameController.AnswerButtonClicked(answerData.isCorrect);
    }
}
