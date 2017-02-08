using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Husk : MonoBehaviour {

	// Use this for initialization
    private Vector3 velocity = Vector3.zero;
    private Vector3 velocity2 = Vector3.zero;
    float randInt1, randInt2;

	void Start () {
        randInt1 = Random.Range(-2.5f, 2.5f);
        randInt2 = Random.Range(-1f, -3f);
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.childCount == 3)
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, new Vector3(0.25f, 0.25f, 0.25f), ref velocity, 0.4f);
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(randInt1,randInt2, transform.position.z), ref velocity2, 0.3f);
            SpriteRenderer[] sprs = GetComponentsInChildren<SpriteRenderer>();
            for(int i = 0; i< transform.childCount; i++)
            {
                transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = (int)(randInt1 * 100);
                transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = (int)(randInt1 * 100 + 1);
                transform.GetChild(2).GetComponent<SpriteRenderer>().sortingOrder = (int)(randInt1 * 100 + 1);
            }
        }
		
	}
}
