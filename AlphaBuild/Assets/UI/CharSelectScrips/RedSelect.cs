using UnityEngine;
using UnityEngine.SceneManagement;


public class RedSelect : MonoBehaviour
{

    public void NextScene()
    {
        PlayerPrefs.SetString("Name", "Red Ralph");
        SceneManager.LoadScene("MainMenu");
    }
}
