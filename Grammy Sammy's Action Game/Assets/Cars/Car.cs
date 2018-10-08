using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;


//this script only affects the cars. Does not handle collision with a player. 
//Makes cars go back to their original position off of the screen to come back in

public class Car : MonoBehaviour
{
	private Camera m_MainCamera;
	private Vector2 startPos;


	public float speed;
	public float respawnBoundary;

	private Car carControllerScript;
	private float timeRemaining; 
	
	// Use this for initialization
	void Start ()
	{
		timeRemaining = 140f;
		m_MainCamera = Camera.main;
		startPos = new Vector2(transform.position.x, transform.position.y);
		
		carControllerScript = gameObject.GetComponent<Car>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		timeRemaining -= Time.deltaTime;
		if (timeRemaining <= 0)
		{
			Debug.Log(timeRemaining);
			carControllerScript.enabled = false; 
		}
		//this is fine and dandy for now but try making it so that it reverts to the original position when
		//it hits the edge of the screen, not just when it exceeds x = 10
		//Debug.Log("Camera width is: " + Screen.width + " and the car is at " + transform.position.x);
		if (speed >= 0 && transform.position.x >= respawnBoundary)
		{
			transform.position = startPos;
		}
		else if (speed <= 0 && transform.position.x <= respawnBoundary)
		{
			transform.position = startPos;
		}

		else
		{
			transform.Translate(Vector2.right * speed);
		}
	}
}
