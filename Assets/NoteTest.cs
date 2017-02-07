using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTest : MonoBehaviour {

    public GameObject micGO;
    Mic mic;
    public float threshold = 1.0f; //change this if screaming is too quiet or loud.

    void Start () {

        micGO = GameObject.Find("Mic Manager");
        mic = micGO.GetComponent<Mic>();
		
	}
	

    void Update () 
    {
        int frequency = (int)mic.frequency;
        print(frequency);
		
	}
}
