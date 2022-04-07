using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gameManager;
    public Canvas initialCanvas;
    public Canvas makeTrade;
    public GameObject initialObj;
    public GameObject makeTradeObj;
    void Start()
    {
        gameManager = GetComponentInParent<GameManager>();
        initialCanvas.enabled = false;
        makeTrade.enabled = false;
        initialObj.SetActive(false);
        makeTradeObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "hero")
        {
            // Pause Game
            gameManager.pause();
            // Create UI to make sanity decisions decisions
            initialCanvas.enabled = true;
            initialObj.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        /*
        initialCanvas.enabled = false;
        makeTrade.enabled = false;
        initialObj.SetActive(false);
        makeTradeObj.SetActive(false);
        gameManager.unpause();
        */
    }

    public void exitTrade()
    {
        initialCanvas.enabled = false;
        makeTrade.enabled = false;
        initialObj.SetActive(false);
        makeTradeObj.SetActive(false);
        gameManager.unpause();
    }

    public void enterTrade()
    {
        gameManager.pause();
        initialCanvas.enabled = false;
        makeTrade.enabled = true;
        makeTradeObj.SetActive(true);
    }

    public void hpBuff()
    {
        if(gameManager != null)
        {
            if (gameManager.getHero().getSanity() >= 10)
            {
                gameManager.hpBuff(20);
                gameManager.sanityCost(10);
            }
        }
    }

    public void attackBuff()
    {
        if (gameManager != null)
        {
            if (gameManager.getHero().getSanity() >= 10)
            {
                gameManager.attackBuff(20);
                gameManager.sanityCost(10);
            }
        }
    }

    public void speedBuff()
    {
        if (gameManager != null)
        {
            if (gameManager.getHero().getSanity() >= 20)
            {
                gameManager.speedBuff(1.25f);
                gameManager.sanityCost(20);
            }
        }
    }
}
