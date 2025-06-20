using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables of our player (the ball)
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerupStrength = 15.0f;
    public float speed = 5.0f;
    public bool hasPowerup = false;
    public GameObject powerupInd;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");        
    }

    // Update is called once per frame
    void Update()
    {
        //Get the input for forward and backwards (up/down arrows)
        float forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);

        powerupInd.transform.position = transform.position + new Vector3(0, -0.5f, 0);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupInd.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupInd.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

            //Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerup);

            
        }
    }
}
