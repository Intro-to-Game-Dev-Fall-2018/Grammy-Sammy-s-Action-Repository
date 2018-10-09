using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

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

	//spriteRenderer to change the sprites when a player scores
	private SpriteRenderer mySpriteRenderer;

	//private PlayerController controllerScript;

	//audio for when a player scores a point
	public AudioClip scoreSoundClip;
	public AudioSource scoreSoundSource;

	public GameObject Collectible;
	private GameObject[] theSingleCollectible;


	void Start()
	{
		scoreNumbers = new Sprite[]
		{
			zero, one, two, three, four, five, six, seven, eight
		};

		mySpriteRenderer = GetComponent<SpriteRenderer>();

		scoreSoundSource.clip = scoreSoundClip;

		theSingleCollectible = new GameObject[1];
		theSingleCollectible[0] = Instantiate(Collectible,
			new Vector3(
				Random.Range(transform.position.x - 3.5f, transform.position.x + 3.5f), 
				Random.Range(transform.position.y - 6.5f, transform.position.y - 2.5f), 
				0.5f),
			transform.rotation);
	}

	void FixedUpdate()
	{
		mySpriteRenderer.sprite = scoreNumbers[score];
	}

	void OnTriggerEnter2D(Collider2D otherObj)
	{
		if (otherObj.CompareTag("Collectibles"))
		{
			Debug.Log("A Player has scored a point!!");
			score += 1;
			Debug.Log(score);

			scoreSoundSource.Play();
			Destroy(otherObj.gameObject);
			Instantiate(Collectible,
				new Vector3(
					Random.Range(transform.position.x - 4f, transform.position.x + 4f), 
					Random.Range(transform.position.y - 6.5f, transform.position.y - 2.5f), 
					0.5f),
				transform.rotation);
		}
	}

	public int getScore()
	{
		return score;
	}
}