using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class sceneManage : MonoBehaviour {

	// Use this for initialization	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
            
	}

	public void SceneLoader(string scene)
	{
		SceneManager.LoadScene(scene);
	}
}
