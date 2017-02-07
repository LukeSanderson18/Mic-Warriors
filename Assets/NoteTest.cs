﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteTest : MonoBehaviour {

    public Text text;
    public GameObject micGO;
    public Transform[] transform_list;
    Mic mic;
    public float threshold = 1.0f; //change this if screaming is too quiet or loud.

    void Start () {

        micGO = GameObject.Find("Mic Manager");
        mic = micGO.GetComponent<Mic>();
        transform_list = GetComponentsInChildren<Transform>();
		
	}


    void Update() 
    {
        int frequency = (int)mic.frequency;
        if (frequency > 40)
        {
            text.text = frequency.ToString();
        }

        switch (Input.inputString)
        {
            case "z":
                print("C PRESSED");
                transform_list[1].GetComponent<AudioSource>().Play();
                break;
            case "x":
                print("D PRESSED");
                transform_list[2].GetComponent<AudioSource>().Play();

                break;
            case "c":
                print("E PRESSED");
                transform_list[3].GetComponent<AudioSource>().Play();

                break;
            case "v":
                print("F PRESSED");
                transform_list[4].GetComponent<AudioSource>().Play();

                break;
            case "b":
                print("G PRESSED");
                transform_list[5].GetComponent<AudioSource>().Play();

                break;
            case "n":
                print("A PRESSED");
                transform_list[6].GetComponent<AudioSource>().Play();

                break;
            case "m":
                print("B PRESSED");
                transform_list[7].GetComponent<AudioSource>().Play();

                break;
            case ",":
                print("C HIGH PRESSED");
                transform_list[8].GetComponent<AudioSource>().Play();

                break;

            default:
                //print("press different key!");
                break;
        }

		
	}
}