using UnityEngine;
using UnityEngine.SceneManagement;


public class PinkSelect : MonoBehaviour {

    public void NextScene()
    {
        PlayerPrefs.SetString("Name", "Pink Peter");
        SceneManager.LoadScene("MainMenu");
    }
}
