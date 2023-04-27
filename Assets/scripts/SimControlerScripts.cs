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
    float Converted;
    float startdelay = 0.0f;
    float timeinterval = 0.2f;
    public ShowingOnScreen OnScreen;
    public UseData Data;
    public GameObject blackOutSquare;
    public GameObject Sailboat;
    public Animator Sailboatanom;

    // Start is called before the first frame update
    void Start()
    {
      //  Sailboatanom = Sailboat.GetComponent<Animator>();
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
            float v1 = float.Parse(Data.Getdata(i, "TulsaConverted"));
            int temp = i + 1;
            float v2 = float.Parse(Data.Getdata(temp, "TulsaConverted"));
            //Converted = float.Parse(Data.Getdata(i, "TulsaConverted"));
            //Debug.Log("The TulsaConverted is: " + Converted);

            ChangeVal(v1, v2, timeinterval);
        

        }
        else if (z == 1)
        {
            OnScreen.Setyear((i + 1985).ToString());
            OnScreen.SetLoc("Oklahoma");
            OnScreen.SetCrime(Data.Getdata(i, "Oklahoma"));
           // Converted = float.Parse(Data.Getdata(i, "OklahomaConverted"));
            //Debug.Log("The OklahomaConverted is: " + Converted);


            ChangeVal(float.Parse(Data.Getdata(i, "OklahomaConverted")), float.Parse(Data.Getdata(i + 1, "OklahomaConverted")), timeinterval);

        }
        else if (z == 2)
        {
            OnScreen.Setyear((i + 1985).ToString());
            OnScreen.SetLoc("United States");
            OnScreen.SetCrime(Data.Getdata(i, "United_States"));
          //  Converted = float.Parse(Data.Getdata(i, "UnitedStatesConverted"));
            //Debug.Log("The UnitedStatesConverted is: " + Converted);

            ChangeVal(float.Parse(Data.Getdata(i, "UnitedStatesConverted")), float.Parse(Data.Getdata(i + 1, "UnitedStatesConverted")), timeinterval);
        }
        else
        {
            i = 0;
            z = 0;// Quit Is Not Working
        }
        Sailboatanom.SetFloat("Blend", Converted);
        i++;
    }

    public IEnumerator ChangeVal(float start, float end, float duration)
    {
        Debug.Log("Blend Started");
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            Converted = Mathf.Lerp(start, end, elapsed/duration);
            elapsed += Time.deltaTime;
            yield return null;
            Sailboatanom.SetFloat("Blend", Converted);
            Debug.Log("The Blend is: " + Converted);
        }
        Converted = end;
        Sailboatanom.SetFloat("Blend", Converted);
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

  


