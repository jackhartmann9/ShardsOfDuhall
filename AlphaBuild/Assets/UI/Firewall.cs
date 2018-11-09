using UnityEngine;
using UnityEngine.SceneManagement;

public class Firewall : MonoBehaviour
{
    public void NextScene()
    {
				Debug.Log("Scene");
        SceneManager.LoadScene("SideScroller");
    }
}
