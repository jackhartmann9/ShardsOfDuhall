using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CodeBreakScene : MonoBehaviour {

	// Use this for initialization
	public void NextScene()
	{
			SceneManager.LoadScene("CodeBreaker");
	}
}
