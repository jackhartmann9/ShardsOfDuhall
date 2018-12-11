using UnityEngine;
using UnityEngine.SceneManagement;


public class PinkSelect : MonoBehaviour {

    public void NextScene()
    {
        string powerText = "Once per game, Peter can move a player back 1 spot after everyone has moved.";
        PlayerPrefs.SetString("Power", powerText);
        PlayerPrefs.SetString("Name", "Pink Peter");
        SceneManager.LoadScene("MainMenu");
    }
}
