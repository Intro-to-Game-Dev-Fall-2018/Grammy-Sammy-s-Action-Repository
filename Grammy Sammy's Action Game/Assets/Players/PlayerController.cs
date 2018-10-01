using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float speed;
	public float startX;
	public float startY;

	private Vector2 startPos;

	// Use this for initialization
	void Start()
	{
		startPos = new Vector2(startX, startY);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (gameObject.tag == "Player RIGHT" && Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(Vector2.up * 0.1f);
			Debug.Log("up arrow pressed");
		}

		else if (gameObject.tag == "Player RIGHT" && Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(Vector2.up * -0.1f);
			Debug.Log("down arrow pressed");
		}

		if (gameObject.tag == "Player LEFT" && Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector2.up * 0.1f);
			Debug.Log("w is pressed");
		}

		else if (gameObject.tag == "Player LEFT" && Input.GetKey(KeyCode.S))
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
	}
}
