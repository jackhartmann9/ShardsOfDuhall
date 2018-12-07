using UnityEngine;
using UnityEngine.SceneManagement;


public class GreenGary : MonoBehaviour
{

    public void NextScene()
    {
        string powerText = "Once per game, Gary can draw a Floppy Card from the Floppy Pile.";
        PlayerPrefs.SetString("Power", powerText);
        PlayerPrefs.SetString("Name", "Green Gary");
        SceneManager.LoadScene("MainMenu");
    }
}
