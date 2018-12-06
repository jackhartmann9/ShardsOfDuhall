using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [SerializeField] private Text questionText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timeText;
    [SerializeField] private Text answerAText;
    [SerializeField] private Text answerBText;
    [SerializeField] private Text answerCText;
    [SerializeField] private Text answerDText;
    [SerializeField] private AnswerButton[] answerButtons;

    private DataController dataController;
    
    private AnswerData answerData;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;
    public GameObject categoryDisplay;
    public int round;

    private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private int playerScore;
    private float timeLeft = 30.0f;

    private void Start()
    {
        categoryDisplay.SetActive(true);
        questionDisplay.SetActive(false);

        dataController = FindObjectOfType<DataController>();
        RoundData currentRoundData = dataController.GetCurrentRoundData(round);

        timeRemaining = currentRoundData.timeLimitInSeconds;

        playerScore = 0;
        questionIndex = 0;

        //ShowQuestion();
        isRoundActive = true;

    }

    public void ShowQuestion()
    {
        RoundData currentRoundData = dataController.GetCurrentRoundData(round);
        QuestionData[] questionPool = currentRoundData.questions;
        QuestionData questionData = questionPool[questionIndex];
        categoryDisplay.SetActive(false);
        questionDisplay.SetActive(true);
        questionText.text = questionData.questionText;
        for (int i = 0; i < answerButtons.Length; i++)
        {
            AnswerData answerData = new AnswerData();
            answerData.answerText = questionData.answers[i].answerText;
            answerData.isCorrect = questionData.answers[i].isCorrect;
            answerButtons[i].Setup(answerData);
            if (i == 0)
            {
                answerAText.text = answerData.answerText;
            }
            if (i == 1)
            {
                answerBText.text = answerData.answerText;
            }
            if (i == 2)
            {
                answerCText.text = answerData.answerText;
            }
            if (i == 3)
            {
                answerDText.text = answerData.answerText;
            }
        }
    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        RoundData currentRoundData = dataController.GetCurrentRoundData(round);
        QuestionData[] questionPool = currentRoundData.questions;
        if (isCorrect)
        {
            playerScore += currentRoundData.pointsAddedForCorrectAnswer;
            scoreText.text = "Score: " + playerScore.ToString();
            questionText.text = "Correct!";
        } else
        {
            questionText.text = "Wrong!";
        }

        if (questionPool.Length > questionIndex + 1)
        {
            StartCoroutine(Wait());
            questionIndex++;
        } else
        {
            StartCoroutine(EndRound());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.75f);
        ShowQuestion();
    }

    IEnumerator EndRound()
    {
        isRoundActive = false;
        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
        yield return new WaitForSeconds(3);
        PlayerPrefs.SetInt("Score", playerScore);
        Destroy(this);
        SceneManager.LoadScene("MainMenu");
    }

     void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft > 0.0f)
        {
            timeText.text = "Time Remaining: " + (timeLeft.ToString("0"));
        }
        if (timeLeft < 0.0f)
        {
            StartCoroutine(EndRound());
        }
    }
}
