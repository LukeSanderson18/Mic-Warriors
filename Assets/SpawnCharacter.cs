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
    string code = "9";
    int delay = 0;


    public Color[] man_colours;
    public Color[] hair_colours;
    public Sprite[] hair_types;
    public Sprite[] shields;

    // text files...
    public TextAsset textFile;
    private string wholeString;
    private List<string> eachLine;

    List<int> digits = new List<int>();


    void Start()
    {
        Generate(int.Parse(code));

    }
    // Update is called once per frame
    public void Generate(int managerCode)
    {
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
        code = "9";
        foreach (int digit in managerCode.ToString())
        {
            digits.Add((int)digit);

        }
        for (int i = 0; i < 7; i++)
        {
            int a = 0;
            if (i == 0)         //SKIN COLOUR
            {
                if (managerCode == 9)
                {
                    a = Random.Range(0, characters.Length - 3);
                }
                else
                {
                    a = digits[0];
                }
                man_sprite.color = man_colours[a];
            }
            if (i == 1)         //HAIR COLOUR
            {
                if (managerCode == 9)
                {
                    a = Random.Range(0, characters.Length - 2);
                }
                else
                {
                    a = digits[1];
                }
                hair_sprite.color = hair_colours[a];
            }
            if (i == 2)         //SHIELD
            {
                if (managerCode == 9)
                {
                    a = Random.Range(0, characters.Length - 3);
                }
                else
                {
                    a = digits[2];
                }
                shield.sprite = shields[a];
            }
            if (i == 3) //gender
            {
                if (managerCode == 9)
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
                else
                {
                    a = digits[3];
                }                
            }
            if (i == 4)
            {

                eachLine = new List<string>();
                eachLine.AddRange(
                            wholeString.Split("\n"[0]));


                if (managerCode == 9)
                {
                    a = Random.Range(0, 8);
                }
                else
                {
                    a = digits[4];
                }
                name1 = a;
            }
            if (i == 5)
            {
                if (managerCode == 9)
                {
                    a = Random.Range(0, 8);
                }
                else
                {
                    a = digits[5];
                }
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
                nameText.text = "Say hello to " +name + "!";

            }
            if (i == 6)
            {
                if (managerCode == 9)
                {
                    a = Random.Range(0, 3);
                }
                else
                {
                    a = digits[6];
                }
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
        Invoke("Detach", 1f);


    }

    void Detach()
    {
       GameObject an =  Instantiate(husk);
       if (int.Parse(code) > 9000000)
       {
           int newint = int.Parse(code);
           newint -= 90000000;
           code = newint.ToString();
       }
       an.name = code;
       code = "";
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
            int noteInt = c-48;
            print(noteInt);

            NoteTester.GetComponent<NoteTest>().transform_list[noteInt].GetComponent<AudioSource>().Play();


            yield return new WaitForSeconds(0.6f);

        }
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Generate(int.Parse(code));

        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ScreamFunction();
        }
    }
}
