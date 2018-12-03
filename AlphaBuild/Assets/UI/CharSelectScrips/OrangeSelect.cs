using UnityEngine;
using UnityEngine.SceneManagement;


public class OrangeSelect : MonoBehaviour
{

    public void NextScene()
    {
        PlayerPrefs.SetString("Name", "Orange Olly");
        SceneManager.LoadScene("MainMenu");
    }
}
