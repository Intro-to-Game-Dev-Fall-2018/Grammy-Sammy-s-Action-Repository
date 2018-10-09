using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenus : MonoBehaviour
{

	public GameObject extraCarsOnMenuScreen;

	public SpriteRenderer oneSpriteRenderer; 

	public String gameScene; 
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Alpha1))
		{
			extraCarsOnMenuScreen.SetActive(true);
			oneSpriteRenderer.enabled = false;
		}

		if (Input.GetKey(KeyCode.Alpha2))
		{
			SceneManager.LoadScene("Game");
		}
	}
}
