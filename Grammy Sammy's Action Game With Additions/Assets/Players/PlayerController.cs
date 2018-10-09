using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
	public Sprite extendedNeckDuck;
	private int switchDuckSpriteCounter;
	
	//freeze the cars and motion controls when the time is up
	private float timeRemaining; 
	private PlayerController playerControllerScript;
	

	public AudioClip collideWithCarSoundClip;
	public AudioSource collideWithCarSoundSource;

	private float timeBeforeMovingAgain;

	// Use this for initialization
	void Start()
	{
		duckSpriteRenderer = GetComponent<SpriteRenderer>();
		startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		switchDuckSpriteCounter = 0;
		
		playerControllerScript = gameObject.GetComponent<PlayerController>();

		collideWithCarSoundSource.clip = collideWithCarSoundClip;

		timeBeforeMovingAgain = 10f; 
	}

	// Update is called once per frame
	void FixedUpdate()
	{	
		//show the duck
		//duckSpriteRenderer.sprite = neutralDuck;
		switchDuckSpriteCounter += 1; 
		Debug.Log(switchDuckSpriteCounter);
		 
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
		if (switchDuckSpriteCounter % 2 == 0)
		{
			duckSpriteRenderer.sprite = neutralDuck;
		}
		else
		{
			duckSpriteRenderer.sprite = extendedNeckDuck;
		}
		
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
			
			//have a slight delay before the player can move again after being sent back to start position
			collideWithCarSoundSource.Play();
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
