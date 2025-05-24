using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables with the speed and the rigidbody of our player (the ball)
    private Rigidbody playerRb;
    public float speed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get the input for forward and backwards (up/down arrows)
        float forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * forwardInput * speed);

    }
}
