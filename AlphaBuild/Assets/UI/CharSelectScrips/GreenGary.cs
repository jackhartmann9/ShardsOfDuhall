using UnityEngine;
using UnityEngine.SceneManagement;


public class GreenGary : MonoBehaviour
{

    public void NextScene()
    {
        PlayerPrefs.SetString("Name", "GreenGary");
        SceneManager.LoadScene("MainMenu");
    }
}
