using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteTest : MonoBehaviour
{
    public Text finaStringText;
    public bool allower = true;
    public string finalString;
    public List<int> finals;
    public bool listening;
    public Text text;
    public GameObject micGO;
    public Transform[] transform_list;
    Mic mic;
    public float threshold = 1.0f; //change this if screaming is too quiet or loud.

    void Start()
    {
        //
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        //
        micGO = GameObject.Find("Mic Manager");
        mic = micGO.GetComponent<Mic>();
        transform_list = GetComponentsInChildren<Transform>();

    }


    void Update()
    {
       // finaStringText.text = finals[0].ToString() + finals[1].ToString() + finals[2].ToString() + finals[3].ToString() + finals[4].ToString() + finals[5].ToString() + finals[6].ToString();

        if (finalString.Length == 7)
        {
            GameObject.Find("ManTest").GetComponent<SpawnCharacter>().GenerateOld(int.Parse(finalString));
            print(int.Parse(finalString));
            finalString = "";

            finals.Clear();

        }
        if (finals.Count == 7)
        {
            finalString = finals[0].ToString() + finals[1].ToString()
                + finals[2].ToString() + finals[3].ToString()
                + finals[4].ToString() + finals[5].ToString() +
                finals[6].ToString();



            // GameObject.Find("Manager").GetComponent<PlayersManager>().AddPlayer(finalString);
        }
        /*if (Input.GetKey(KeyCode.L))
        {
            listening = true;
        }
        else
        {
            listening = false;
            finals.Clear();
        }
         * */

        if (listening)
        {
            print("i am listening");
            int frequency = (int)mic.frequency;

            //PC FREQUENCIES

            if (frequency == 239 || frequency == 240
                || frequency == 479 || frequency == 480
                || (frequency >= 958 && frequency <= 961))
            {
                text.text = "C";
                if (allower)
                {
                    finals.Add(1);
                    allower = false;
                }
            }
            if (frequency == 269 || frequency == 270
                || frequency == 539 || frequency == 540
                || (frequency >= 806 && frequency <= 810))
            {
                text.text = "D";
                if (allower)
                {
                    finals.Add(2);
                    allower = false;
                }

            }
            if (frequency == 302 || frequency == 454
                || frequency == 604 || frequency == 605
                || frequency == 606
                || (frequency >= 907 && frequency <= 909))
            {
                text.text = "E";
                if (allower)
                {
                    finals.Add(3);
                    allower = false;
                }
            }
            if (frequency == 321 || frequency == 322
                || frequency == 640 || frequency == 641
                || frequency == 481
                || (frequency >= 962 && frequency <= 964))                        //this is bad!!!
            {
                text.text = "F";
                if (allower)
                {
                    finals.Add(4);
                    allower = false;
                }
            }
            if (frequency == 360 || frequency == 361
                || frequency == 721 || frequency == 718
                || (frequency >= 1079 && frequency <= 1083))
            {
                text.text = "G";
                if (allower)
                {
                    finals.Add(5);
                    allower = false;
                }
            }
            if (frequency == 201 || frequency == 203 || frequency == 405
                || frequency == 403
                || (frequency >= 1214 && frequency <= 1218))
            {
                text.text = "A";
                if (allower)
                {
                    finals.Add(6);
                    allower = false;
                }
            }
            if (frequency == 227 || frequency == 228
                || frequency == 453 || frequency == 454
                || (frequency >= 909 && frequency <= 913))
            {
                text.text = "B";
                if (allower)
                {
                    finals.Add(7);
                    allower = false;
                }
            }

            else if (frequency < 100)
            {
                allower = true;
                // text.text = "" + frequency;
            }
            else
            {
                // text.text = "" + frequency;
            }

            switch (Input.inputString)
            {
                case "z":
                    print("C PRESSED");
                    transform_list[1].GetComponent<AudioSource>().Play();
                    break;
                case "x":
                    print("D PRESSED");
                    transform_list[2].GetComponent<AudioSource>().Play();

                    break;
                case "c":
                    print("E PRESSED");
                    transform_list[3].GetComponent<AudioSource>().Play();

                    break;
                case "v":
                    print("F PRESSED");
                    transform_list[4].GetComponent<AudioSource>().Play();

                    break;
                case "b":
                    print("G PRESSED");
                    transform_list[5].GetComponent<AudioSource>().Play();

                    break;
                case "n":
                    print("A PRESSED");
                    transform_list[6].GetComponent<AudioSource>().Play();

                    break;
                case "m":
                    print("B PRESSED");
                    transform_list[7].GetComponent<AudioSource>().Play();

                    break;
                case ",":
                    print("C HIGH PRESSED");
                    transform_list[8].GetComponent<AudioSource>().Play();

                    break;

                default:
                    //print("press different key!");
                    break;
            }

        }
       


    }
}
