using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

//this is attached to the score sprites the appear at the top of the screen
//it handles showing the score only, it does not deal with the ducks at all
//other than detecting a duck has collided with it

public class ScoreCounter : MonoBehaviour
{
	private int score;
	
	//store all of the score Sprites in an array
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
	public Sprite ten;
	public Sprite eleven;
	public Sprite twelve;
	public Sprite thirteen;
	public Sprite fourteen;
	public Sprite fifteen;
	public Sprite sixteen;
	public Sprite seventeen;
	public Sprite eighteen;
	public Sprite nineteen;
	public Sprite twenty;
	
	//spriteRenderer to change the sprites when a player scores
	private SpriteRenderer mySpriteRenderer;
	
	
	//audio for when a player scores a point
	public AudioClip scoreSoundClip;
	public AudioSource scoreSoundSource;
	
	void Start()
	{
		//save the score sprites in an array
		scoreNumbers = new Sprite[]
		{
			zero, one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve,
			thirteen, fourteen, fifteen, sixteen, seventeen, eighteen, nineteen, twenty
		};
		
		//get sprite renderer to be able to change the sprite
		mySpriteRenderer = GetComponent<SpriteRenderer>();

		//define the audio clip 
		scoreSoundSource.clip = scoreSoundClip;
	}

	//switch the sprite showing the score
	void FixedUpdate()
	{
		mySpriteRenderer.sprite = scoreNumbers[score];
	}

	//detect if the player has entered the goal zone
	//score a point and play the sound
	void OnTriggerEnter2D(Collider2D otherObj)
	{
		if (otherObj.CompareTag("Player RIGHT") || otherObj.CompareTag("Player LEFT"))
		{
			Debug.Log("A Player has scored a point!!");
			score += 1;

			scoreSoundSource.Play();
		}
	}

	//getter for the score
	public int getScore()
	{
		return score;
	}
}