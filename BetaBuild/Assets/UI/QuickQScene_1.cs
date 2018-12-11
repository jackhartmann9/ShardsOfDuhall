using UnityEngine;
using UnityEngine.SceneManagement;

public class QuickQScene : MonoBehaviour
{

    public void NextScene()
    {
      SceneManager.LoadScene("QuizGame");
        SceneManager.LoadScene("Persistent", LoadSceneMode.Additive);
    }
}
