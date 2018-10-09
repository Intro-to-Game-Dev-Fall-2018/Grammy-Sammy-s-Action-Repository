using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;


//this script only affects the cars. Does not handle collision with a player. 
//Makes cars go back to their original position off of the screen to come back in
//This is purely for the movement of the cars. Does not handle the triggers
//between player and car

public class Car : MonoBehaviour
{
	private Vector2 startPos;


	public float speed;
	public float respawnBoundary;
	
	// Use this for initialization
	void Start ()
	{
		startPos = new Vector2(transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update ()
	{
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
