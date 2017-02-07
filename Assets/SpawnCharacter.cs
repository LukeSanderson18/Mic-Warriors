using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour {

    private string characters = "1234567";
    SpriteRenderer man_sprite;
    SpriteRenderer hair_sprite;

    public Color[] colours;

    void Start()
    {
        man_sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
	// Update is called once per frame
	void Generate () 
    {
        string code = "";

        for (int i = 0; i < 7; i++)
        {
            int a = 0;
            if (i == 0)         //SKIN COLOUR
            {
                a = Random.Range(0, characters.Length - 2);
                man_sprite.color = colours[a];
            }
            if (i == 1)         //HAIR COLOUR
            {
                a = Random.Range(0, characters.Length - 1);
            }
            if (i == 2)         //SHIELD
            {
                a = Random.Range(0, characters.Length);
            }
            if (i == 3)
            {
                a = Random.Range(0, 2);
            }
            if (i == 4 || i == 5)
            {
                a = Random.Range(0, characters.Length);
            }
            if (i == 6)
            {
                a = Random.Range(0, characters.Length-1);
            }

                
            //int a = Random.Range(0, characters.Length);
            code = code + characters[a];
        }

        print(code);
		
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Generate();

        }
    }
}
