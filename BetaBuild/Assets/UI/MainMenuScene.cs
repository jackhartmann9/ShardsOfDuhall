using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScene : MonoBehaviour
{
    public void NextScene()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("CharSelect");
    }
}
