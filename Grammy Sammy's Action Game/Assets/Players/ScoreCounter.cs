using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
	private int score;
	
	private Sprite[] scoreNumbers;

	public Sprite zero;
	public Sprite one;
	public Sprite two;
	public Sprite three;
	public Sprite four;
	public Sprite five;
	public Sprite six;
	public Sprite seven;
	public Sprite eight;
	public Sprite nine;
	
	private SpriteRenderer mySpriteRenderer;
	
	private PlayerController controllerScript;
	
	void Start()
	{
		scoreNumbers = new Sprite[]
		{
			zero, one, two, three, four, five, six, seven, eight, nine
		};
		
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		controllerScript = gameObject.GetComponent<PlayerController>();
	}

	void FixedUpdate()
	{
		mySpriteRenderer.sprite = scoreNumbers[score];
		/*if (score >= 10)
		{
			mySpriteRenderer.sprite = scoreNumbers
		}*/
	}

	void OnTriggerEnter2D(Collider2D otherObj)
	{

		if (otherObj.CompareTag("Player RIGHT") || otherObj.CompareTag("Player LEFT"))
		{
			Debug.Log("A Player has scored a point!!");
			score += 1;

			//transform.position = startPos;
		}

	}


	/*
	public Text scoreCounter;
	private int score;

	//player's initial position
	public float startX;
	public float startY;
	private Vector2 startPos;

	//game ends after 2 minutes 20 seconds! 
	private float timeRemaining;

	//sprites for the score
	private Sprite[] scoreNumbers;

	public Sprite zero;
	public Sprite one;
	public Sprite two;
	public Sprite three;
	public Sprite four;
	public Sprite five;
	public Sprite six;
	public Sprite seven;
	public Sprite eight;
	public Sprite nine;

	private SpriteRenderer mySpriteRenderer;

	//reference to the player controller scripts from this one 
	private PlayerController controllerScript;


	// Use this for initialization
	void Start()
	{
		//startPos = new Vector2(startX, startY);
		score = 0;
		timeRemaining = 100f;
		//140f;

		scoreNumbers = new Sprite[]
		{
			zero, one, two, three, four, five, six, seven, eight, nine
		};

		mySpriteRenderer = GetComponent<SpriteRenderer>();
		controllerScript = gameObject.GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update()
	{
		mySpriteRenderer.sprite = scoreNumbers[score];
		
		//Debug.Log(timeRemaining);
		if (timeRemaining <= 0)
		{
			//disable movement and the cars
			Debug.Log("game is over. Player controllers disabled.");
			controllerScript.enabled = false;

			StartBlinking();
		}

		ShowScore();
	}

	void OnTriggerEnter2D(Collider2D otherObj)
	{

		if (otherObj.CompareTag("Player RIGHT"))
		{
			Debug.Log("A Player has scored a point!!");
			score += 1;

			//transform.position = startPos;
		}

	}

	void ShowScore()
	{
		//scoreCounter.text = score.ToString();
		timeRemaining -= Time.deltaTime;
		if (timeRemaining <= 5)
		{
			StartBlinking();
		}
	}

	IEnumerator Blink()
	{
		while (true)
		{
			switch (scoreCounter.color.a.ToString())
			{
				case "0":
					scoreCounter.color = new Color(scoreCounter.color.r, scoreCounter.color.g, scoreCounter.color.b, 1);
					yield return new WaitForSeconds(0.5f);
					break;
				case "1":
					scoreCounter.color = new Color(scoreCounter.color.r, scoreCounter.color.g, scoreCounter.color.b, 0);
					yield return new WaitForSeconds(0.5f);
					break;
			}
		}
	}

	void StartBlinking()
	{
		StopCoroutine("Blink");
		StartCoroutine("Blink");
	}

	void StopBlinking()
	{
		StopCoroutine("Blink");
	}
}

*/
}