using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{

    public Sprite[] monsterSprites;
    public GameObject monsterHusk;
    public int nextMonsterHP;
    public int totalKilled = 0;
    public int monsterNumber = 1;

    Monster mon;
    // Use this for initialization
    public void Start()
    {
        Generate();
    }
    public void Generate()
    {
        //print("AAAAAAAAAAA" + PlayerPrefs.GetInt("monsterNumber"));

        if (PlayerPrefs.HasKey("monsterNumber"))
        {
            print("true");
            if(PlayerPrefs.GetInt("monsterNumber") == 0)
            {
                PlayerPrefs.SetInt("monsterNumber", 1);
            }
            monsterNumber = PlayerPrefs.GetInt("monsterNumber");
        }
        else
        {
            PlayerPrefs.SetInt("monsterNumber", 1);
        }

        int randInt = Random.Range(0, monsterSprites.Length);

        GameObject monster = Instantiate(monsterHusk, new Vector2(0, 2), Quaternion.identity);
        monster.transform.localScale = Vector3.one * 4;
        monster.name = monsterSprites[randInt].name;
        monster.transform.GetChild(0).GetComponent<TextMesh>().text = monster.name;
        monster.transform.GetChild(0).parent = null;

        mon = monster.GetComponent<Monster>();
        mon.GetComponent<SpriteRenderer>().sprite = monsterSprites[randInt];

        mon.maxhealth = PlayerPrefs.GetInt("monsterNumber") * PlayerPrefs.GetInt("monsterNumber");
        mon.health = mon.maxhealth;
        mon.monsterNumber = PlayerPrefs.GetInt("monsterNumber");

        monster.SetActive(true);
    }
}
