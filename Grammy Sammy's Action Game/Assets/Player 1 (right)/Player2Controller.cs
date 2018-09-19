using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{

    public float speed;
    public float startLocation;

    Rigidbody2D myRigidbody;

    private Vector2 startPos; 

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        //Vector2 v1 = new Vector2(0, 1)
        //Vector2 v2 = new Vector2(0, 1, 0);
        startPos = new Vector2(-5.07f, -4.31f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * 0.1f);
            Debug.Log("w is pressed");
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.up * -0.1f);
            Debug.Log("down arrow pressed");
        }
    }

    private void OnTriggerEnter2D(Collider2D otherObj)
    {
        if (otherObj.CompareTag("Car"))
        {
            Debug.Log("Player has collided with a car!");
            transform.position = startPos;
        }
    }
}