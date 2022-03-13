using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityMessage : MonoBehaviour
{
    // Start is called before the first frame update

    private bool displayed = false;
    private GameManager gameManager;
    public int sanityLevelCap;
    private Canvas canvas;
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        gameManager = GetComponentInParent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!displayed && gameManager.getHero().getSanity() <= sanityLevelCap)
        {
            gameManager.pause();
            canvas.enabled = true;
            Debug.Log("less than level cap");
        } else
        {
            Debug.Log(gameManager.getHero().getSanity());
        }
    }

    public void exitSanityMessage()
    {
        displayed = true;
        gameObject.SetActive(false);
        canvas.enabled = false;
        gameManager.unpause();
    }
}
