using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

<<<<<<< HEAD:AlphaBuild/Assets/Scripts/GameController.cs
    public Question[] questions;
    private static List<Question> unansweredQuestions;
=======
    [SerializeField] private Text questionText;
    [SerializeField] private Text scoreText;

    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;
    private AnswerData answerData;
    private AnswerButton answerButton;
>>>>>>> Austin_Build:AlphaBuild/Assets/Quiz Game/Scripts/GameController.cs

    private Question currentQuestion;
    public static int score;

    [SerializeField] private Text factText;
    [SerializeField] private Text scoreText;
    [SerializeField] private float answerDelay = 1f;

    private void Start()
    {
<<<<<<< HEAD:AlphaBuild/Assets/Scripts/GameController.cs
        scoreText.text = "Score: " + score;
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }
=======
        dataController = FindObjectOfType<DataController>();
        answerButton = FindObjectOfType<AnswerButton>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        timeRemaining = currentRoundData.timeLimitInSeconds;
>>>>>>> Austin_Build:AlphaBuild/Assets/Quiz Game/Scripts/GameController.cs

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
<<<<<<< HEAD:AlphaBuild/Assets/Scripts/GameController.cs
        unansweredQuestions.Remove(currentQuestion);
=======
        QuestionData questionData = questionPool[questionIndex];
        questionText.text = questionData.questionText;
        answerButton.Setup(answerData);
>>>>>>> Austin_Build:AlphaBuild/Assets/Quiz Game/Scripts/GameController.cs

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
