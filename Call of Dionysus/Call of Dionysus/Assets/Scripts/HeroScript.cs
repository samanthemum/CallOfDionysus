using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    public static float speed = .1f;
    public Rigidbody2D heroRB;

    // Start is called before the first frame update
    void Start()
    {
        heroRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float y_factor = (int)Input.GetAxis("Vertical");
        float x_factor = (int)Input.GetAxis("Horizontal");

        float current_y = heroRB.position.y;
        float current_x = heroRB.position.x;

        heroRB.MovePosition(new Vector2(current_x + (x_factor * speed), current_y + (y_factor * speed)));
    }
}
