using UnityEngine;
using UnityEngine.SceneManagement;


public class GreenGary : MonoBehaviour
{

    public void NextScene()
    {
        PlayerPrefs.SetString("Name", "Green Gary");
        SceneManager.LoadScene("MainMenu");
    }
}
