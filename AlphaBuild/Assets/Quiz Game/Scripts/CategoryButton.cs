using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryButton : MonoBehaviour
{

    private AnswerData answerData;
    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void HandleClick()
    {
        if (gameObject.CompareTag("Geography"))
        {
            gameController.round = 0;
        }
        if (gameObject.CompareTag("Sports"))
        {
            gameController.round = 1;
        }
        if (gameObject.CompareTag("Music"))
        {
            gameController.round = 2;
        }
        if (gameObject.CompareTag("History"))
        {
            gameController.round = 3;
        }
        if (gameObject.CompareTag("VideoGames"))
        {
            gameController.round = 4;
        }
        if (gameObject.CompareTag("General"))
        {
            gameController.round = 5;
        }
        gameController.ShowQuestion();
        gameController.timeLeft = 30.0f;

    }
}
