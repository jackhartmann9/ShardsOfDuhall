using UnityEngine;
using UnityEngine.SceneManagement;


public class BlueSelect: MonoBehaviour
{

    public void NextScene()
    {
        PlayerPrefs.SetString("Name", "Blue Betty");
        SceneManager.LoadScene("MainMenu");
    }
}
