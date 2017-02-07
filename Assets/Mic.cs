using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mic : MonoBehaviour
{


    AudioSource audio;

    public float sensitivity = 100f;
    public float loud = 0;
    // Use this for initialization
    void Start()
    {
        foreach (string device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }

        audio = GetComponent<AudioSource>();
        audio.loop = true;
        audio.mute = true;
        //record from first audio device, loop it, 10 seconds length, Hz;
        audio.clip = Microphone.Start(null, true, 2, 44100);

        while (!(Microphone.GetPosition(Microphone.devices[0]) > 0)) { } // Wait until the recording has started
        audio.mute = false;
        audio.Play();



    }

    public float AverageVol()
    {
        float[] data = new float[256]; //lovely number
        audio.GetOutputData(data, 0); //last int is channel
        float i = 0;                       //HAS TO BE ZERO GRR
        foreach (float asda in data)
        {
            i += Mathf.Abs(asda);
        }
        return i / data.Length; //get the mean
    }

    void Update()
    {
        loud = AverageVol() * sensitivity;
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "" + loud;
    }
}
