using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private bool isGamePaused = false;
    public int pointValue;

    // Start is called before the first frame update
    void Start() {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        transform.position = new Vector3(Random.Range(-700, 150), 1, Random.Range(-13, 13));
    }

    //Collision Detection
    void OnTriggerEnter(Collider Collectable) {
            if (Collectable.gameObject.CompareTag("Gem"))
            {
                Destroy(Collectable.gameObject);
                gameManager.UpdateScore(pointValue);

            }

            if (Collectable.gameObject.CompareTag("Box"))
            {
                //isGamePaused = true;
                gameManager.GameOver();
            }
    }

    //To pause the game
    private void Update()
    {
        if (isGamePaused)
        {
            Time.timeScale = 0f;
        }

        else
        {
            Time.timeScale = 1f;
        }
    }
}
