﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{

    public int health;
    public int maxhealth;
    public int monsterNumber;
    public Image img;
    PlayersManager pm;
    // Use this for initialization
    void Start()
    {
        img = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        pm = GameObject.Find("Manager").GetComponent<PlayersManager>();
    }
    void OnMouseDown()
    {
        health-= pm.totalPlayers;
        GetComponent<Shake>().shakeDuration = 0.2f;
    }

    void Update()
    {
        float div = (float)health / (float)maxhealth;
        img.fillAmount = div;
        print(health/maxhealth);
        if (health <= 0)
        {
            int min = PlayerPrefs.GetInt("monsterNumber");
            int min2 = min += 1;
            PlayerPrefs.SetInt("monsterNumber", min2);
            GameObject.Find("MonsterGen").GetComponent<MonsterGenerator>().Generate();
            Destroy(GameObject.Find("name"), 0);
            Destroy(this.gameObject, 0);
        }

        
    }
}
