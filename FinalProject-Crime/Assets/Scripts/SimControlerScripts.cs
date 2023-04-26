using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class SimControlerScripts : MonoBehaviour
{
    int i = 0;
    int z = 0;

    float startdelay = 0.0f;
    float timeinterval = 0.2f;
    public ShowingOnScreen OnScreen;
    public UseData Data;
    public GameObject blackOutSquare;

    // Start is called before the first frame update
    void Start()
    {
        //Data = GameObject.Find("UseDataObject");
        InvokeRepeating("loopFiltering", startdelay, timeinterval);

    }

    void loopFiltering()
    {

       StartCoroutine(FadeBlackOutSquare(false));
        if (i == 36)
        {
            i = 0;
            z++;
            StartCoroutine(FadeBlackOutSquare());
        }

        if (z == 0)
        {
            OnScreen.Setyear((i + 1985).ToString());
            OnScreen.SetLoc("Tulsa");
            OnScreen.SetCrime(Data.Getdata(i, "Tulsa"));
        }
        else if (z == 1)
        {
            OnScreen.Setyear((i + 1985).ToString());
            OnScreen.SetLoc("Oklahoma");
            OnScreen.SetCrime(Data.Getdata(i, "Oklahoma"));
        }
        else if (z == 2)
        {
            OnScreen.Setyear((i + 1985).ToString());
            OnScreen.SetLoc("United States");
            OnScreen.SetCrime(Data.Getdata(i, "United_States"));
        }
        else
        {
            Application.Quit(); // Quit Is Not Working
        }

        i++;
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, int fadeSpeed = 15)
    {
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (blackOutSquare.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;

            }
        }
        else
        {
            while (blackOutSquare.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }

        }
    }
}

  


