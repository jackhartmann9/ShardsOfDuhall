using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;
    public static int score;

    [SerializeField] private Text factText;
    [SerializeField] private Text scoreText;
    [SerializeField] private float answerDelay = 1f;

    private void Start()
    {
        scoreText.text = "Score: " + score;
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();
        
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;
    }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(answerDelay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UserSelectTrue()
    {
        if (currentQuestion.isTrue)
        {
            score++;
            scoreText.text = "Score: " + score;
        } else
        {
            Debug.Log("Wrong!");
        }
        StartCoroutine(TransitionToNextQuestion());
    }
    public void UserSelectFalse()
    {
        if (!currentQuestion.isTrue)
        {
            score++;
            scoreText.text = "Score: " + score;
        } else
        {
            Debug.Log("Wrong!");
        }
        StartCoroutine(TransitionToNextQuestion());
    }
}
