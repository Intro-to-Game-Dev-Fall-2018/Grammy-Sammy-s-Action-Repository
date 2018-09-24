using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class Car1 : MonoBehaviour
{
	private Camera m_MainCamera;
	private Vector2 startPos;

	public float startX;
	public float startY;
	public float speed;
	
	// Use this for initialization
	void Start ()
	{
		m_MainCamera = Camera.main;
		startPos = new Vector2(startX, startY);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//this is fine and dandy for now but try making it so that it reverts to the original position when
		//it hits the edge of the screen, not just when it exceeds x = 10
		//Debug.Log("Camera width is: " + Screen.width + " and the car is at " + transform.position.x);
		if (speed >= 0 && transform.position.x >= 10)
		{
			transform.position = startPos;
		}
		else if (speed <= 0 && transform.position.x <= -10)
		{
			transform.position = startPos;
		}

		else
		{
			transform.Translate(Vector2.right * speed);
		}
	}
}
