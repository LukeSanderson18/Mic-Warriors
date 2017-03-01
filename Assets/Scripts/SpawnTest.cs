using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour {

    public GameObject micManager;
    public Mic mic;

    public float threshold = 1f;
    public GameObject prefab;
	// Use this for initialization
	void Start () {
        micManager = GameObject.Find("Mic Manager");
        mic = micManager.GetComponent<Mic>();
	}
	
	// Update is called once per frame
	void Update () {
        float i = mic.loud;

        //print(i + "," + threshold);
        if (i > threshold)
        {
            print("WORKS WORKS WORKS!");
          //  Vector3 test = Vector3.one;
          //  GameObject an = Instantiate(prefab, transform.position, Quaternion.identity);
           // an.transform.localScale += test;
        }
	}
}
