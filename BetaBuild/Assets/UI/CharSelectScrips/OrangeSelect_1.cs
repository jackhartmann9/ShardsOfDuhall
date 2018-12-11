using UnityEngine;
using UnityEngine.SceneManagement;


public class OrangeSelect : MonoBehaviour
{

    public void NextScene()
    {
        string powerText = "Once per game, Olly can choose to discard and redraw a Floppy Card.";
        PlayerPrefs.SetString("Power", powerText);
        PlayerPrefs.SetString("Name", "Orange Olly");
        SceneManager.LoadScene("MainMenu");
    }
}
