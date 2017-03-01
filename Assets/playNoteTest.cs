using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playNoteTest : MonoBehaviour {


    public AudioSource audi;
    void Start()
    {
        audi = GetComponent<AudioSource>();
    }
    public void Click()
    {
        audi.Play();

    }
}
