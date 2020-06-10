using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Keeps track of the player */

public class PlayerManager : MonoBehaviour
{

	#region Singleton

	public static PlayerManager instance;
	private Enemy[] enemies;

	void Awake()
	{
		instance = this;
		enemies = GameObject.FindObjectsOfType<Enemy>();
	}

	#endregion

	public GameObject player;

	public void KillPlayer()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	

	private void Update() {
		foreach(Enemy e in enemies){
			if(e != null)
				return;
		}

		Time.timeScale = 0;
	}
}
