using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Microphone;

public class Mic : MonoBehaviour
{


    AudioSource audio;

    public float sensitivity = 100f;
    public float loud = 0;
    public int samplerate = 11024;

    public float frequency = 0f;
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
        audio.clip = Microphone.Start(null, true, 10, 44100);

        while (!(Microphone.GetPosition(null) > 0)) { } // Wait until the recording has started
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

    float GetFundamentalFrequency()
    {
        float fundamentalFrequency = 0f;
        float[] data = new float[8192];
        audio.GetSpectrumData(data, 0, FFTWindow.BlackmanHarris);

        float strongestTemp = 0f;
        int strongestFreq = 0;
        for (int i = 1; i < 8192; i++)
        {
            if (strongestTemp < data[i])
            {
                strongestTemp = data[i];
                strongestFreq = i;
            }
        }
        fundamentalFrequency = strongestFreq * samplerate / 8192;
        return fundamentalFrequency;
    }

    void Update()
    {
        loud = AverageVol() * sensitivity;
        frequency = GetFundamentalFrequency();
        //transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "" + loud;
    }
}
