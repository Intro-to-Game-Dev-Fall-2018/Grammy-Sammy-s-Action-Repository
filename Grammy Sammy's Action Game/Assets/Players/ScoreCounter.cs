using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

	public Text scoreCounter;
	private int score;

	public float startX;
	public float startY;
	private Vector2 startPos;

	private float timeRemaining;
	
	// Use this for initialization
	void Start ()
	{
		startPos = new Vector2(startX, startY);
		score = 0;
		timeRemaining = 140f;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		ShowScore();
	}

	void OnTriggerEnter2D(Collider2D otherObj)
	{
		if (otherObj.CompareTag("Goal"))
		{
			Debug.Log("Player has scored a point!!");
			score += 1;
			transform.position = startPos;
		}
	}
	
	void ShowScore()
	{
		scoreCounter.text = score.ToString();
		//what's the win condition? 
		//seems like it's a timer? After some amount of time the scores
		//flash and whoever has the highest score wins... But 
		//also no special screen for the winner 
		//just that the scores flash colours
		//2 minutes 20 seconds
		//additionally, score starts to flash about 5 seconds before
		//game actually ends to let the user know game is almost over.
		timeRemaining -= Time.deltaTime;
		if (timeRemaining <= 5)
		{
			StartBlinking();
		}
		else if (timeRemaining <= 0)
		{
			//disable movement and the cars

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

