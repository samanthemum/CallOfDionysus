using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class openingscene : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;
    private int currentScene = 1;
    public Image mainScene;
    public Image scene2;
    public Image scene3;
    public Image scene4;
    public Text lore;

    void Start()
    {
        scene2.enabled = false;
        scene3.enabled = false;
        scene4.enabled = false;
        lore.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void continueButton() {

        if(currentScene == 1)
        {
            button.GetComponentInChildren<Text>().text = "Go to bed";
            mainScene.sprite = scene2.sprite;
        } else if(currentScene == 2)
        {
            button.GetComponentInChildren<Text>().text = "Go panic";
            mainScene.sprite = scene3.sprite;
        }
        else if (currentScene == 3)
        {
            lore.enabled=true;
            button.GetComponentInChildren<Text>().text = "Go to hell";
            mainScene.sprite = scene4.sprite;
            mainScene.color = scene4.color;
        } else
        {
            SceneManager.LoadScene("Level1");
        }

        currentScene++;
    }
}
