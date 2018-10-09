using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
	public GameObject playerRight;
	public GameObject playerLeft;
	public GameObject masterCarController;

	public GameObject player1WinText;
	public GameObject player2WinText;

	private float timeRemaining;

	public GameObject playerRightScoreObject;
	public GameObject playerLeftScoreObject;
	private int playerRightScoreVal;
	private int playerLeftScoreVal;

	private bool ifSlowDownCollected;
	private float powerUpTimer;

	// Use this for initialization
	void Start()
	{
		powerUpTimer = 7f;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		playerRightScoreVal = playerRightScoreObject.GetComponent<ScoreCounter>().getScore();
		playerLeftScoreVal = playerLeftScoreObject.GetComponent<ScoreCounter>().getScore();

		/*if (playerRight.GetComponent<PlayerController>().getSlowDownTrackerStatus() && powerUpTimer >= 0)
		{
			masterCarController.GetComponent<MasterCarController>().slowCarsRight(powerUpTimer);
			powerUpTimer = masterCarController.GetComponent<MasterCarController>().slowCarsRight(powerUpTimer);
		}*/
		
		if (Input.GetKey(KeyCode.Alpha2))
		{
			SceneManager.LoadScene("Game");
		}

		if (Input.GetKey(KeyCode.Escape)) 
		{
			playerRight.GetComponent<PlayerController>().enabled = false;
			playerLeft.GetComponent<PlayerController>().enabled = false;
			masterCarController.GetComponent<MasterCarController>().enabled = true;
		}

		if (playerLeftScoreVal >= 5)
		{
			playerRight.GetComponent<PlayerController>().enabled = false;
			playerLeft.GetComponent<PlayerController>().enabled = false;
			masterCarController.GetComponent<MasterCarController>().enabled = true;

			player1WinText.SetActive(true);
		}
		
		if (playerRightScoreVal >= 5)
		{
			playerRight.GetComponent<PlayerController>().enabled = false;
			playerLeft.GetComponent<PlayerController>().enabled = false;
			masterCarController.GetComponent<MasterCarController>().enabled = true;

			player2WinText.SetActive(true);
		}
	}
}