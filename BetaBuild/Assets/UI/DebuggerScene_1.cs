using UnityEngine;
using UnityEngine.SceneManagement;

public class DebuggerScene : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("SnakeGame");
    }
}
