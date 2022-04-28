using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClosingScene : MonoBehaviour
{
    // Start is called before the first frame update

    public Text lore;
    public Image mainScene;
    public Image scene2;
    public Button button;
    private int currentScene = 1;
    void Start()
    {
        scene2.enabled = false;
        lore.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void continueButton()
    {

        if (currentScene == 1)
        {
            lore.enabled = true;
            button.GetComponentInChildren<Text>().text = "Go home";
            mainScene.sprite = scene2.sprite;
            mainScene.color = scene2.color;
        }
        else if (currentScene == 2)
        {
            SceneManager.LoadScene("MainMenu");
        }
        currentScene++;
    }
}
