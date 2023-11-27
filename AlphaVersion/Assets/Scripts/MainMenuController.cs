using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour {

    //public CanvasGroup OptionPanel;
    //private GameManager gameManager;

    private Button button;
    private GameManager gameManager;
    public int difficulty;

    // Start is called before the first frame update
    void Start() {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        button.onClick.AddListener(StartGame);
    }

    void StartGame() {
        Debug.Log(difficulty + " was clicked");
        //gameManager.StartGame(difficulty);
        gameManager.StartGame(difficulty);

    }

    //Switch to the game scene
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Switch back to the menu scene
    public void QuitGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}