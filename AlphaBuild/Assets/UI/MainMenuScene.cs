using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScene : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
