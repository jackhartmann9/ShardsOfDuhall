using UnityEngine;
using UnityEngine.SceneManagement;

public class Firewall : MonoBehaviour
{
    public void NextScene()
    {
				
        SceneManager.LoadScene("SideScroller");
    }
}
