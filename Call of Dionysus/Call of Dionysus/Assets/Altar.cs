using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gameManager;
    public Canvas initialCanvas;
    public Canvas makeTrade;
    void Start()
    {
        gameManager = GetComponentInParent<GameManager>();
        initialCanvas.enabled = false;
        makeTrade.enabled = false;
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
        }
    }

    public void exitTrade()
    {
        initialCanvas.enabled = false;
        makeTrade.enabled = false;
        gameManager.unpause();
    }

    public void enterTrade()
    {
        initialCanvas.enabled = false;
        makeTrade.enabled = true;
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
                gameManager.speedBuff(1.5f);
                gameManager.sanityCost(20);
            }
        }
    }
}
