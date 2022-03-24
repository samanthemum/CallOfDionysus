using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script for controlling the main menu buttons
public class MainMenuButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gameManager;
    void Start()
    {
        gameManager = GetComponentInParent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // TODO: PUT CAP IF WE BEAT THE GAME
    public void playLevel()
    {
        SceneManager.LoadScene("Level" + gameManager.getLevel());
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void help()
    {
        SceneManager.LoadScene("Help");
    }
}
