using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour {

    public string newString;
    public List<int> players;
	// Use this for initialization
    void Start()
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i] = int.Parse(PlayerPrefs.GetString("players" + i));
            if (players[i] != 0)
            {
                StartCoroutine(Create(i, players[i]));
               // Invoke("Create", i);
            }
        }

    }

    IEnumerator Create(float delayTime, int playerTING)
    {
        yield return new WaitForSeconds(delayTime+1.8f);
        //GameObject.Find("ManTest").GetComponent<SpawnCharacter>().Generate(playerTING);
    }
    void Create()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject.Find("ManTest").GetComponent<SpawnCharacter>().GenerateOld(players[0]);
        }
    }
    public void AddPlayer(string newPlayerString)
    {
        newString = newPlayerString;

        for (int i = 0; i < players.Count; i++)
        {
            if (players[i] == 0)
            {
                players[i] = int.Parse(newString);
                PlayerPrefs.SetString("players" + i, newPlayerString);
                print("adsfasdfasdf asdf asdf asdf " + PlayerPrefs.GetString("players" + i));
                break;
            }

        }
        /*
        foreach (char c in newPlayerString)
        {
            if (c == 'C')
            {
                newString += "1";
            }
            if (c == 'D')
            {
                newString += "2";
            }
            if (c == 'E')
            {
                newString += "3";
            }
            if (c == 'F')
            {
                newString += "4";
            }
            if (c == 'G')
            {
                newString += "5";
            }
            if (c == 'A')
            {
                newString += "6";
            }
            if (c == 'B')
            {
                newString += "7";
            }
        }
         * */


    }
}
