using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTimer : MonoBehaviour
{
	private Car carMovementScript;

	private float timeRemaining;

	private int numberOfCars;

	private Car[] carList;

	public Transform currentCar;
	
	// Use this for initialization
	void Start ()
	{
		timeRemaining = 140f;
		numberOfCars = transform.childCount;

		carList = GetComponentsInChildren<Car>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		timeRemaining -= Time.deltaTime;
		if (timeRemaining <= 0)
		{
			for (int i = 0; i < numberOfCars; i++)
			{
				currentCar = this.gameObject.transform.GetChild(i);
				carMovementScript = currentCar.GetComponent<Car>();
				carMovementScript.enabled = false;
			}
			/*foreach (Car childCar in carList)
			{
				carMovementScript = gameObject.GetComponentInChildren<Car>();
				carMovementScript.enabled = false;
			}	*/		
		}
	}
}
