using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mic : MonoBehaviour {


    AudioSource audio;
	// Use this for initialization
	void Start () {

        audio = GetComponent<AudioSource>();
        audio.loop = true;
        audio.mute = true;
        //record from first audio device, loop it, 10 seconds length, Hz;
        audio.clip = Microphone.Start(null, true, 10, 44100);

        while (!(Microphone.GetPosition(AudioInputDevice) > 0)) { } // Wait until the recording has started
        audio.Play();

   
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
