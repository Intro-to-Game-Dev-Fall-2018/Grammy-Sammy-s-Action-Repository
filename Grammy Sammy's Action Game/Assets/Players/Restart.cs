using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
	private GameObject playerObj;
	
	// Use this for initialization
	void Start ()
	{
		playerObj = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//playerObj.GetComponent<Player1Controller>().enabled = true;
		
		if (Input.GetKey(KeyCode.Alpha2))
		{
			SceneManager.LoadScene("Game");
		}

		if (Input.GetKey(KeyCode.Escape))
		{
			playerObj.GetComponent<PlayerController>().enabled = !true;
		}
	}
}
