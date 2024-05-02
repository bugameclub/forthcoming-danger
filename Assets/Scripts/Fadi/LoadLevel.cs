using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
	//Pass the level name to load
    public void loadLevel(string levelName)
    {
			Time.timeScale = 1f;
		
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }

}
