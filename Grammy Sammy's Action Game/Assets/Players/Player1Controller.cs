using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
	
	public float speed;
	public float startX;
	public float startY;

	Rigidbody2D myRigidbody;

	private Vector2 startPos; 

	// Use this for initialization
	void Start()
	{
		myRigidbody = GetComponent<Rigidbody2D>();

		//Vector2 v1 = new Vector2(0, 1)
		//Vector2 v2 = new Vector2(0, 1, 0);
		startPos = new Vector2(startX, startY);
	}

	// Update is called once per frame
	void FixedUpdate()
	{

		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(Vector2.up * 0.1f);
			Debug.Log("up arrow pressed");
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(Vector2.up * -0.1f);
			Debug.Log("down arrow pressed");
		}
	}

	void OnTriggerEnter2D(Collider2D otherObj)
	{
		if (otherObj.CompareTag("Car"))
		{
			Debug.Log("Player has collided with a car!");
			transform.position = startPos;
		}

		/*if (otherObj.CompareTag("Goal"))
		{
			Debug.Log("Player 1 has scored a point!");
		}*/
	}
}

/*
if (Input.GetKeyDown(KeyCode.UpArrow))
{
	Debug.Log("Up Arrow Key pressed");
	myRigidbody.velocity = new Vector2(0, 1);
}

else if (Input.GetKeyUp(KeyCode.UpArrow))
{
	Debug.Log("Up arrow released");
	myRigidbody.velocity = new Vector2(0, 0);
}

if (Input.GetKeyDown(KeyCode.DownArrow))
{
	Debug.Log("down arrow pressed");
	myRigidbody.velocity = new Vector2(0, -1);
}
else if (Input.GetKeyUp(KeyCode.DownArrow))
{
	Debug.Log("down arrow released");
	myRigidbody.velocity = new Vector2(0, 0);
} */
