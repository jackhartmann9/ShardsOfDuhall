using UnityEngine;
using UnityEngine.SceneManagement;


public class YellowSelect : MonoBehaviour {

    public void NextScene()
    {
        string powerText = "Once per game, Yara can subtract 3 points from another players score.";
        PlayerPrefs.SetString("Power", powerText);
        PlayerPrefs.SetString("Name", "Yellow Yara");
        SceneManager.LoadScene("MainMenu");
    }
}
