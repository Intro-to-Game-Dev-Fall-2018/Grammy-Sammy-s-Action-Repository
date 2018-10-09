using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class MasterCarController : MonoBehaviour
{
	private Car carMovementScript;

	private float timeRemaining;

	private int numberOfCars;

	private Car[] carList;

	public Transform currentCar;

	public float powerUpTimeRemaining;
	
	// Use this for initialization
	void Start ()
	{
		timeRemaining = 140f;
		numberOfCars = transform.childCount;

		carList = GetComponentsInChildren<Car>();

		//powerUpTimeRemaining = 7f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		for (int i = 0; i < numberOfCars; i++)
		{
		currentCar = this.gameObject.transform.GetChild(i);
		carMovementScript = currentCar.GetComponent<Car>();
		carMovementScript.enabled = false;
		}	
	}

	/*
	public float slowCarsRight(float powerUpTimeRemaining)
	{
		powerUpTimeRemaining -= Time.deltaTime;

		if (powerUpTimeRemaining >= 0)
		{
			for (int i = 0; i < numberOfCars; i++)
			{
				Debug.Log("Entered (second) for loop)");
				currentCar = this.gameObject.transform.GetChild(i);
				if (currentCar.transform.position.x >= 0)
				{
					Debug.Log("Entered second if statement");
					carMovementScript = currentCar.GetComponent<Car>();
					carMovementScript.speed = carMovementScript.speed / 2f;
					Debug.Log(carMovementScript.speed);
				}
			}
		}

		return powerUpTimeRemaining;
	}*/
}
