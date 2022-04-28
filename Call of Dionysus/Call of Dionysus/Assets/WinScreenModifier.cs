using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenModifier : MonoBehaviour
{
    // Start is called before the first frame update
    public Text message;
    public GameManager gameManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.getLevel() == 2)
        {
            message.text = "It seems you must descend further.";
        } else if(gameManager.getLevel() == 3)
        {
            message.text = "Darkness consumes you. Yet, she remains.";
        } else
        {
            message.text = "SHE IS NEAR.";
        }
    }
}
