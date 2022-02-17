using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayEnemyHP : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyScript enemy;

    void Start()
    {
        enemy = GetComponentInParent<EnemyScript>();
        GetComponent<TMPro.TextMeshPro>().text = "HP: " + enemy.getHP().ToString() + "/" + enemy.getMaxHP().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMPro.TextMeshPro>().text = "HP: " + enemy.getHP().ToString() + "/" + enemy.getMaxHP().ToString();
    }
}
