using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> GoodTargets;
    public List<GameObject> BadTargets;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameOverText;
    public Button restartButton;
    public Button quitButton;
    
    public GameObject titleScreen;
    //public GameObject player;

    public bool isGameActive;
    private int score;
    private bool isGamePaused = false;
    private float spawnRate = 1.5f;
    private float startDelay = 1.5f;

    // Start is called before the first frame update
    void Start () {

        //InvokeRepeating("SpawnTarget", startDelay, spawnRate);

        //score = 0;
        //scoreText.text = "Score: " + score;

        //UpdateScore(0);
        //StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, GoodTargets.Count);
            int index2 = Random.Range(0, BadTargets.Count);
            Instantiate(GoodTargets[index]);
            Instantiate(BadTargets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void StartGame(int difficulty) {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        spawnRate /= difficulty;
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    public void GameOver() {
        GameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        isGameActive = false;
        isGamePaused = true;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

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

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
