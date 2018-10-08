using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//properties of the duck
	//the speed at which it can move and its start position
	public float speed;
	private Vector3 startPos;

	//duck sprites
	private SpriteRenderer duckSpriteRenderer;
	public Sprite neutralDuck;
	
	//freeze the cars and motion controls when the time is up
	private float timeRemaining; 
	private PlayerController playerControllerScript;
	//public GameObject car;
	//private Car carControllerScript;
	

	// Use this for initialization
	void Start()
	{
		duckSpriteRenderer = GetComponent<SpriteRenderer>();
		startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

		playerControllerScript = gameObject.GetComponent<PlayerController>();

		//car = GameObject.FindWithTag("Car");
		//carControllerScript = car.GetComponent<Car>();
		
		timeRemaining = 140f;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		//decrease the timer and freeze all controls and movement if the timer is below 0
		timeRemaining -= Time.deltaTime;
		if (timeRemaining <= 0)
		{
			playerControllerScript.enabled = false;
			//carControllerScript.enabled = false;
		}
		
		//show the duck
		duckSpriteRenderer.sprite = neutralDuck;
		
		//movement for both players depending on the tag
		if (gameObject.tag == "Player RIGHT" && Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(Vector2.up * 0.1f);
		}

		else if (gameObject.tag == "Player RIGHT" && Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(Vector2.up * -0.1f);
		}

		if (gameObject.tag == "Player LEFT" && Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector2.up * 0.1f);
		}

		else if (gameObject.tag == "Player LEFT" && Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector2.up * -0.1f);
		}
	}

	void OnTriggerEnter2D(Collider2D otherObj)
	{
		//send the player back to the start position if it hits a car
		if (otherObj.CompareTag("Car"))
		{
			transform.position = startPos;
		}

		//send the player back to the start position if it hits the goal
		if (otherObj.CompareTag("Goal"))
		{
			Debug.Log("Player has hit the upper boundary");
			transform.position = startPos;
		}
	}
}
