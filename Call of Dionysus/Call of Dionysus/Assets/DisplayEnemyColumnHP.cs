using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayEnemyColumnHP : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyColumnScript enemy;

    void Start()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "HP: " + enemy.getHP().ToString() + "/" + enemy.getMaxHP().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "HP: " + enemy.getHP().ToString() + "/" + enemy.getMaxHP().ToString();
    }
}
