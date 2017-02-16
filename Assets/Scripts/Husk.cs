using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Husk : MonoBehaviour {

	// Use this for initialization
    private Vector3 velocity = Vector3.zero;
    private Vector3 velocity2 = Vector3.zero;
    int randShadow;
    public List<GameObject> shadows;
    bool foundPlace;
    Vector3 newplace = Vector3.zero;


    void Start () {

        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("shadow"))
        {
            shadows.Add(fooObj);
        }

    }
	
    void FindFreeSpace()
    {
        randShadow = Random.Range(0, GameObject.FindGameObjectsWithTag("shadow").Length);
        while (newplace == Vector3.zero && !foundPlace)
        {
            if (!shadows[randShadow].GetComponent<shadow>().taken)
            {
                newplace = shadows[randShadow].transform.position;
                shadows[randShadow].GetComponent<shadow>().taken = true;
                foundPlace = true;
                //break;
            }
            else
            {
                FindFreeSpace();            //such bad code... OH WELL!
            }
        }
    }

    void Update () {

        
        if (transform.childCount == 3)
        {
            FindFreeSpace();

            transform.localScale = Vector3.SmoothDamp(transform.localScale, new Vector3(0.25f, 0.25f, 0.25f), ref velocity, 0.1f);
            transform.position = Vector3.SmoothDamp(transform.position, newplace, ref velocity2, 0.1f);
            SpriteRenderer[] sprs = GetComponentsInChildren<SpriteRenderer>();
            for(int i = 0; i< transform.childCount; i++)
            {
                transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = (int)(transform.position.y * -100);
                transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = (int)(transform.position.y * -100 + 1);
                transform.GetChild(2).GetComponent<SpriteRenderer>().sortingOrder = (int)(transform.position.y * -100 + 1);
            }
        }
		
	}
}
