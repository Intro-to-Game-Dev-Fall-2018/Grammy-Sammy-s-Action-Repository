using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


//THIS IS THE SCRIPT IN THE GAME WITH CHANGES
public class PlayerController : MonoBehaviour
{
	//ducks start position
	private Vector3 startPos;

	//duck sprites
	private SpriteRenderer duckSpriteRenderer;
	public Sprite neutralDuck;
	public Sprite extendedNeckDuck;
	private int switchDuckSpriteCounter;
	private float switchDuckSpriteTimer;

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
		switchDuckSpriteTimer = 0.25f;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		//show the duck
		//duckSpriteRenderer.sprite = neutralDuck;
		switchDuckSpriteCounter += 1;
		if (switchDuckSpriteCounter >= 100)
		{
			switchDuckSpriteCounter = 0;
		}

		//movement for both players depending on the tag
		if (gameObject.tag == "Player RIGHT" && Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(Vector2.up * 0.1f);
			if (switchDuckSpriteCounter % 10 == 0)
			{
				duckSpriteRenderer.sprite = neutralDuck;
			}
			else if (switchDuckSpriteCounter % 10 == 5)
			{
				duckSpriteRenderer.sprite = extendedNeckDuck;
			}
		}

		else if (gameObject.tag == "Player RIGHT" && Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(Vector2.up * -0.1f);
			if (switchDuckSpriteCounter % 10 == 0)
			{
				duckSpriteRenderer.sprite = neutralDuck;
			}
			else if (switchDuckSpriteCounter % 10 == 5)
			{
				duckSpriteRenderer.sprite = extendedNeckDuck;
			}
		}

		else if (gameObject.tag == "Player RIGHT" && Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector2.right * 0.1f);
			if (switchDuckSpriteCounter % 10 == 0)
			{
				duckSpriteRenderer.sprite = neutralDuck;
			}
			else if (switchDuckSpriteCounter % 10 == 5)
			{
				duckSpriteRenderer.sprite = extendedNeckDuck;
			}
		}

		else if (gameObject.tag == "Player RIGHT" && Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(Vector2.right * -0.1f);
			if (switchDuckSpriteCounter % 10 == 0)
			{
				duckSpriteRenderer.sprite = neutralDuck;
			}
			else if (switchDuckSpriteCounter % 10 == 5)
			{
				duckSpriteRenderer.sprite = extendedNeckDuck;
			}
		}

		if (gameObject.tag == "Player LEFT" && Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector2.up * 0.1f);
			if (switchDuckSpriteCounter % 10 == 0)
			{
				duckSpriteRenderer.sprite = neutralDuck;
			}
			else if (switchDuckSpriteCounter % 10 == 5)
			{
				duckSpriteRenderer.sprite = extendedNeckDuck;
			}
		}

		else if (gameObject.tag == "Player LEFT" && Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector2.up * -0.1f);
			if (switchDuckSpriteCounter % 10 == 0)
			{
				duckSpriteRenderer.sprite = neutralDuck;
			}
			else if (switchDuckSpriteCounter % 10 == 5)
			{
				duckSpriteRenderer.sprite = extendedNeckDuck;
			}
		}

		else if (gameObject.tag == "Player LEFT" && Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector2.right * 0.1f);
			if (switchDuckSpriteCounter % 10 == 0)
			{
				duckSpriteRenderer.sprite = neutralDuck;
			}
			else if (switchDuckSpriteCounter % 10 == 5)
			{
				duckSpriteRenderer.sprite = extendedNeckDuck;
			}
		}

		else if (gameObject.tag == "Player LEFT" && Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector2.right * -0.1f);
			if (switchDuckSpriteCounter % 10 == 0)
			{
				duckSpriteRenderer.sprite = neutralDuck;
			}
			else if (switchDuckSpriteCounter % 10 == 5)
			{
				duckSpriteRenderer.sprite = extendedNeckDuck;
			}
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

			duckSpriteRenderer.sprite = neutralDuck;
		}
		
		if (otherObj.CompareTag("Collectibles"))
		{
			Debug.Log("Collided with a collectible");
			otherObj.transform.parent = this.transform;
			otherObj.transform.position = new Vector3(this.transform.position.x + 0.3f,
				this.transform.position.y + 0.4f,
				this.transform.position.z);
		}
	}
}
