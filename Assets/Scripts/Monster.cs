using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    public int health;
    public int maxhealth;
    public int monsterNumber;
    // Use this for initialization
    void OnMouseDown()
    {
        health--;
        GetComponent<Shake>().shakeDuration = 0.2f;
    }

    void Update()
    {
        if (health <= 0)
        {
            int min = PlayerPrefs.GetInt("monsterNumber");
            int min2 = min += 1;
            PlayerPrefs.SetInt("monsterNumber", min2);
            GameObject.Find("MonsterGen").GetComponent<MonsterGenerator>().Generate();
            Destroy(this.gameObject, 0);
        }

        
    }
}
