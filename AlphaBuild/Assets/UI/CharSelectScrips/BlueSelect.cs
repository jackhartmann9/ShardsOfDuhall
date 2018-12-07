using UnityEngine;
using UnityEngine.SceneManagement;


public class BlueSelect: MonoBehaviour
{

    public void NextScene()
    {
        string powerText = "Once per game, Betty can move 1 spot forwards or backwards.";
        PlayerPrefs.SetString("Name", "Blue Betty");
        PlayerPrefs.SetString("Power", powerText);
        SceneManager.LoadScene("MainMenu");
    }
}
