using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float rollingSpeed = 20.0f;

    public float zRange = 13;
    public float yRange = 0;
    //public float xRange = -1685;

    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        //playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //move the ball forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //move player left/right by arrows
        horizontalInput = Input.GetAxis("Horizontal");
        Vector3 MoveBall = new Vector3(0, 0, horizontalInput);
        gameObject.transform.GetComponent<Rigidbody>().AddForce(MoveBall * rollingSpeed);

        //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * (speed + 20));



        //to keep the player in the screen
        if (transform.position.z < -zRange) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        if (transform.position.y < -yRange) {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }

        if (transform.position.y < yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
    }
}