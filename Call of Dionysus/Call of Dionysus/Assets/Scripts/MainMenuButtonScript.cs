using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script for controlling the main menu buttons
public class MainMenuButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gameManager;
    public AudioSource buttonClick;
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
        buttonClick.Play();
        SceneManager.LoadScene("opening_scene");
    }

    // TODO: PUT CAP IF WE BEAT THE GAME
    public void playLevel()
    {
        buttonClick.Play();
        SceneManager.LoadScene("Level" + gameManager.getLevel());
    }

    public void returnToMainMenu()
    {
        buttonClick.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void help()
    {
        buttonClick.Play();
        SceneManager.LoadScene("Help");
    }
}
