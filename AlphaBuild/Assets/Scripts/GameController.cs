using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [SerializeField] private Text questionText;
    [SerializeField] private Text scoreText;

    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;

    public GameObject questionDisplay;
    public GameObject roundEndDisplay;

    private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private int playerScore;

    private void Start()
    {
        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        timeRemaining = currentRoundData.timeLimitInSeconds;

        playerScore = 0;
        questionIndex = 0;

        ShowQuestion();
        isRoundActive = true;

    }

    private void ShowQuestion()
    {
        QuestionData questionData = questionPool[questionIndex];
        questionText.text = questionData.questionText;
        //answerButton.Setup(answerData);

    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            playerScore += currentRoundData.pointsAddedForCorrectAnswer;
            scoreText.text = "Score: " + playerScore.ToString();
        }

        if (questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            ShowQuestion();
        } else
        {
            EndRound();
        }
    }

    public void EndRound()
    {
        isRoundActive = false;

        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }
}
