using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenButtonScript : MonoBehaviour
{
    public bool StartButton;
    public bool ListenButton;
    public bool ResetButton;
    NoteTest nt;
    // Use this for initialization
    void Start()
    {
        if (StartButton)
            Invoke("Check", 0.01f);

        nt = GameObject.Find("SpawnTest").GetComponent<NoteTest>();
    }

    void Check()
    {
        if (GameObject.Find("Manager").GetComponent<PlayersManager>().players[0] == 0)
        {
            print(GameObject.Find("Manager").GetComponent<PlayersManager>().players[0]);
           // gameObject.SetActive(true);
        }
        else
        {
           // gameObject.SetActive(false);
        }
    }

    public void Listen()
    {
        nt.listening = !nt.listening;

        if (nt.listening)
        {
            GetComponent<Image>().color = Color.red;
        }
        else
        {
            GetComponent<Image>().color = Color.white;
            nt.finalString = "";
            nt.finals.Clear();

        }
    }

    public void Resetter()
    {
        PlayerPrefs.DeleteAll();
        Application.LoadLevel(Application.loadedLevel);
    }
}
