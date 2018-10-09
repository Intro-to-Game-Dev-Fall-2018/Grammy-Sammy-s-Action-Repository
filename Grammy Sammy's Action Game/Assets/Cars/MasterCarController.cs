using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the script that is attached to the parent of all of the cars
//it handles disabling the movement of the cars when necessary

public class MasterCarController : MonoBehaviour
{
	private Car carMovementScript;

	private int numberOfCars;

	public Transform currentCar;
	
	// Use this for initialization
	void Start ()
	{
		numberOfCars = transform.childCount;
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
}
