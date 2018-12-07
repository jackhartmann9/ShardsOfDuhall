using UnityEngine;
using UnityEngine.SceneManagement;


public class RedSelect : MonoBehaviour
{

    public void NextScene()
    {
        string powerText = "Every time Ralph plays Quick Q, add 1 point to his score.";
        PlayerPrefs.SetString("Power", powerText);
        PlayerPrefs.SetString("Name", "Red Ralph");
        SceneManager.LoadScene("MainMenu");
    }
}
