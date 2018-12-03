using UnityEngine;
using UnityEngine.SceneManagement;


public class YellowSelect : MonoBehaviour {

    public void NextScene()
    {
        PlayerPrefs.SetString("Name", "Yellow Yara");
        SceneManager.LoadScene("MainMenu");
    }
}
