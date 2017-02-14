using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCharacter : MonoBehaviour
{
    public GameObject husk;
    public GameObject manPrefab;
    public GameObject hairPrefab;
    public GameObject shieldPrefab;
    public GameObject NoteTester;
    public Text nameText;
    private string characters = "12345678";
    SpriteRenderer man_sprite;
    SpriteRenderer hair_sprite;
    SpriteRenderer shield;
    public string gender = "";
    public string name = "";
    public int name1 = 0;
    public int name2 = 0;
    public int sum = 0;
    public string code = "0";
    int delay = 0;


    public Color[] man_colours;
    public Color[] hair_colours;
    public Sprite[] hair_types;
    public Sprite[] shields;

    // text files...
    public TextAsset textFile;
    private string wholeString;
    private List<string> eachLine;

    public List<int> digits = new List<int>();

    public void Generate()
    {
        code = null;

        GameObject an1 = Instantiate(manPrefab);
        GameObject an2 = Instantiate(hairPrefab);
        GameObject an3 = Instantiate(shieldPrefab);

        an1.transform.parent = transform;
        an2.transform.parent = transform;
        an3.transform.parent = transform;

        an1.transform.localScale = an2.transform.localScale = an3.transform.localScale = Vector3.one;

        man_sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        hair_sprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        shield = transform.GetChild(2).GetComponent<SpriteRenderer>();

        wholeString = textFile.text;
        man_sprite.GetComponent<SpriteRenderer>().enabled = true;

        for (int i = 0; i < 7; i++)
        {
            int a = 0;
            if (i == 0)         //SKIN COLOUR
            {
                a = Random.Range(0, characters.Length - 3);
                man_sprite.color = man_colours[a];
            }
            if (i == 1)         //HAIR COLOUR
            {
                a = Random.Range(0, characters.Length - 2);
                hair_sprite.color = hair_colours[a];
            }
            if (i == 2)         //SHIELD
            {
                a = Random.Range(0, characters.Length - 3);
                shield.sprite = shields[a];
            }
            if (i == 3) //gender
            {
                a = Random.Range(0, 2);
                if (a == 0)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
            }
            if (i == 4)
            {

                eachLine = new List<string>();
                eachLine.AddRange(
                            wholeString.Split("\n"[0]));

                a = Random.Range(0, 8);
                name1 = a;
            }
            if (i == 5)
            {
                a = Random.Range(0, 8);
                name2 = a;
                if (gender == "Male")
                {
                    sum = (name1 * 10 + name2);
                    name =
                        eachLine[sum];
                }
                else
                {
                    sum = (name1 * 10 + name2);
                    name = eachLine[78 + sum];
                }
                nameText.text = "Say hello to " + name + "!";

            }
            if (i == 6)
            {
                a = Random.Range(0, 3);
                if (gender == "Male")
                {
                    hair_sprite.sprite = hair_types[a];
                }
                else
                {
                    hair_sprite.sprite = hair_types[a + 3];
                }
            }

            //int a = Random.Range(0, characters.Length);
            code = code + characters[a];
        }

        print(code);
        GameObject.Find("Manager").GetComponent<PlayersManager>().AddPlayer(code);
        Invoke("Detach", 0.2f);


    }

    public void GenerateOld(int othercode)
    {
        code = null;
        digits.Clear();

        GameObject an1 = Instantiate(manPrefab);
        GameObject an2 = Instantiate(hairPrefab);
        GameObject an3 = Instantiate(shieldPrefab);

        an1.transform.parent = transform;
        an2.transform.parent = transform;
        an3.transform.parent = transform;

        an1.transform.localScale = an2.transform.localScale = an3.transform.localScale = Vector3.one;

        man_sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        hair_sprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        shield = transform.GetChild(2).GetComponent<SpriteRenderer>();

        wholeString = textFile.text;
        man_sprite.GetComponent<SpriteRenderer>().enabled = true;

        foreach (char digit in othercode.ToString())
        {
            print(digit);
            digits.Add((int)(digit-48));

        }
        for (int i = 0; i < 7; i++)
        {
            int a = 0;
            a = digits[i];
            code = code + characters[a];

            man_sprite.color = man_colours[digits[0]];
            hair_sprite.color = hair_colours[digits[1]];
            shield.sprite = shields[digits[2]];

            if (digits[3] == 0)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }

            eachLine = new List<string>();
            eachLine.AddRange(
                        wholeString.Split("\n"[0]));

            name1 = digits[4];
            name2 = digits[5];

            if (gender == "Male")
            {
                sum = (name1 * 10 + name2);
                name =
                    eachLine[sum];
            }
            else
            {
                sum = (name1 * 10 + name2);
                name = eachLine[78 + sum];
            }
            nameText.text = "Say hello to " + name + "!";

            if (gender == "Male")
            {
                hair_sprite.sprite = hair_types[digits[6]];
            }
            else
            {
                hair_sprite.sprite = hair_types[digits[6] + 3];
            }
        }
        /*
        for (int i = 0; i < 7; i++)
        {
            int a = 0;
            if (i == 0)         //SKIN COLOUR
            {
                a = Random.Range(0, characters.Length - 3);
                man_sprite.color = man_colours[a];
            }
            if (i == 1)         //HAIR COLOUR
            {
                a = Random.Range(0, characters.Length - 2);
                hair_sprite.color = hair_colours[a];
            }
            if (i == 2)         //SHIELD
            {
                a = Random.Range(0, characters.Length - 3);
                shield.sprite = shields[a];
            }
            if (i == 3) //gender
            {
                a = Random.Range(0, 2);
                if (a == 0)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
            }
            if (i == 4)
            {

                eachLine = new List<string>();
                eachLine.AddRange(
                            wholeString.Split("\n"[0]));

                a = Random.Range(0, 8);
                name1 = a;
            }
            if (i == 5)
            {
                a = Random.Range(0, 8);
                name2 = a;
                if (gender == "Male")
                {
                    sum = (name1 * 10 + name2);
                    name =
                        eachLine[sum];
                }
                else
                {
                    sum = (name1 * 10 + name2);
                    name = eachLine[78 + sum];
                }
                nameText.text = "Say hello to " + name + "!";

            }
            if (i == 6)
            {
                a = Random.Range(0, 3);
                if (gender == "Male")
                {
                    hair_sprite.sprite = hair_types[a];
                }
                else
                {
                    hair_sprite.sprite = hair_types[a + 3];
                }
            }

            //int a = Random.Range(0, characters.Length);
            code = code + characters[a];
        }

        print(code);
        GameObject.Find("Manager").GetComponent<PlayersManager>().AddPlayer(code);
        Invoke("Detach", 0.2f);
        */

    }

    void Detach()
    {
        GameObject an = Instantiate(husk);
        an.name = code;
        for (int i = transform.childCount; i > 0; i--)           //have to do it backwards for some effing reason.
        {
            transform.GetChild(0).parent = an.transform;
        }
    }

    public void ScreamFunction()
    {
        StartCoroutine(Scream());
    }
    IEnumerator Scream()
    {
        foreach (char c in code)
        {
            //Invoke("PlayNote", 0);
            int noteInt = c - 48;
            print(noteInt);

            NoteTester.GetComponent<NoteTest>().transform_list[noteInt].GetComponent<AudioSource>().Play();


            yield return new WaitForSeconds(0.6f);

        }
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Generate();

        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ScreamFunction();
        }
    }
}
