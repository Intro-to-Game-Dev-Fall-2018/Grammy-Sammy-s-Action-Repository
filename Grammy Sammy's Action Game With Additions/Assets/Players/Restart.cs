using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
	public GameObject playerRight;
	public GameObject playerLeft;
	public GameObject masterCarController;

	private float timeRemaining;

	public GameObject playerRightScoreObject;
	public GameObject playerLeftScoreObject;
	private int playerRightScoreVal;
	private int playerLeftScoreVal;

	// Use this for initialization
	void Start()
	{
		timeRemaining = 140f;

		playerRightScoreVal = 0;
		playerLeftScoreVal = 0;
		
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		playerRightScoreVal = playerRightScoreObject.GetComponent<ScoreCounter>().getScore();
		playerLeftScoreVal = playerLeftScoreObject.GetComponent<ScoreCounter>().getScore();
		
		timeRemaining -= Time.deltaTime;
		
		if (Input.GetKey(KeyCode.Alpha2))
		{
			SceneManager.LoadScene("Game");
		}

		if (Input.GetKey(KeyCode.Escape) || timeRemaining <= 0 || playerRightScoreVal >= 20 || playerLeftScoreVal >= 20) 
		{
			playerRight.GetComponent<PlayerController>().enabled = false;
			playerLeft.GetComponent<PlayerController>().enabled = false;
			masterCarController.GetComponent<CarTimer>().enabled = true;
		}
	}
}