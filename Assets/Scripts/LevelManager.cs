using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void callLevel (string name) {
		Application.LoadLevel(name);
		Brick.breakableCount = 0;
	}

	public void quitGame (string name) {
		Application.Quit();
	}

	public void loadNextLevel ()
	{
		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void brickDestroyed ()
	{
		if(Brick.breakableCount <= 0) {
			loadNextLevel();
		}
	}
}
