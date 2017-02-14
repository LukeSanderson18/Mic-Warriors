using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenButtonScript : MonoBehaviour
{
    public bool StartButton;
    public bool ListenButton;
    // Use this for initialization
    void Start()
    {
        if (StartButton)
            Invoke("Check", 0.01f);

        if (ListenButton)
            Invoke("Listen", 0.01f);
    }

    void Check()
    {
        if (GameObject.Find("Manager").GetComponent<PlayersManager>().players[0] == 0)
        {
            print(GameObject.Find("Manager").GetComponent<PlayersManager>().players[0]);
            print("im allowed to live");
            gameObject.SetActive(true);
        }
        else
        {
            print("kill me");
            gameObject.SetActive(false);
        }
    }

    void Listen()
    {

    }
}
