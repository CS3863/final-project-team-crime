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
    float timeinterval = 1.0f;
    public ShowingOnScreen OnScreen;
    public UseData Data;
    public GameObject blackOutSquare;
    public GameObject sailboatGO;
    public Animator sailboatAnimator;
    public GameObject yachtGO;
    public Animator yachtAnimator;
    public GameObject shipGO;
    public Animator shipAnimator;
    public GameObject oceanGO;
    public Animator oceanAnimator;

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
            oceanAnimator.Play("OceanWaves", 0, 0f);
            sailboatAnimator.Play("Sailboat", 0, 0f);
            yachtAnimator.Play("Yacht", 0, 0f);
            shipAnimator.Play("CruiseShip", 0, 0f);
        }
      
        if (z == 0)
        { 
            sailboatGO.SetActive(true);
            yachtGO.SetActive(false);
            shipGO.SetActive(false);
            OnScreen.Setyear((i + 1985).ToString());
            OnScreen.SetLoc("Tulsa");
            float v1 = sailboatAnimator.GetFloat("Sail");
            OnScreen.SetCrime(Data.Getdata(i, "Tulsa"));
            float v2 = float.Parse(Data.Getdata(i, "TulsaConverted"));

            //Converted = float.Parse(Data.Getdata(i, "TulsaConverted"));
            //Debug.Log("The TulsaConverted is: " + Converted);
            StartCoroutine(ChangeVal(v1, v2, timeinterval));
        }
        else if (z == 1)
        {
            sailboatGO.SetActive(false);
            yachtGO.SetActive(true);
            shipGO.SetActive(false);
            OnScreen.Setyear((i + 1985).ToString());
            OnScreen.SetLoc("Oklahoma");
            float v1 = yachtAnimator.GetFloat("Yacht");
            OnScreen.SetCrime(Data.Getdata(i, "Oklahoma"));
            float v2 = float.Parse(Data.Getdata(i, "OklahomaConverted"));

            // Converted = float.Parse(Data.Getdata(i, "OklahomaConverted"));
            //Debug.Log("The OklahomaConverted is: " + Converted);

            StartCoroutine(ChangeVal(v1, v2, timeinterval));
        }
        else if (z == 2)
        {
            sailboatGO.SetActive(false);
            yachtGO.SetActive(false);
            shipGO.SetActive(true);
            OnScreen.Setyear((i + 1985).ToString());
            OnScreen.SetLoc("United States");
            float v1 = shipAnimator.GetFloat("Cruise");
            OnScreen.SetCrime(Data.Getdata(i, "United_States"));
            float v2 = float.Parse(Data.Getdata(i, "UnitedStatesConverted"));
            //  Converted = float.Parse(Data.Getdata(i, "UnitedStatesConverted"));
            //Debug.Log("The UnitedStatesConverted is: " + Converted);

            StartCoroutine(ChangeVal(v1, v2, timeinterval));
        }
        else
        {
            i = 0;
            z = 0;// Quit Is Not Working
        }
        i++;
        Debug.Log(i);
    }

    public IEnumerator ChangeVal(float start, float end, float duration)
    {
        //Debug.Log("Blend Started");
        float elapsed = 0.0f;
        if (z == 0) 
        { 
            while (elapsed < duration)
            {
                Converted = Mathf.Lerp(start, end, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
                sailboatAnimator.SetFloat("Sail", Converted);
                oceanAnimator.SetFloat("Wave", Converted);
            }
            Debug.Log(Converted);
            //Debug.Log("Sail " + sailboatAnimator.GetFloat("Sail"));
            //Debug.Log("Wave " + oceanAnimator.GetFloat("Wave"));
            Converted = end;
            sailboatAnimator.SetFloat("Sail", Converted);
            oceanAnimator.SetFloat("Wave", Converted);
        }

        if (z ==1)
        {
            while (elapsed < duration)
            {
                Converted = Mathf.Lerp(start, end, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
                yachtAnimator.SetFloat("Yacht", Converted);
                oceanAnimator.SetFloat("Wave", Converted);
            }
            Debug.Log(Converted);
            Converted = end;
            yachtAnimator.SetFloat("Yacht", Converted);
            oceanAnimator.SetFloat("Wave", Converted);
        }

        if (z == 2)
        {
            while (elapsed < duration)
            {
                Converted = Mathf.Lerp(start, end, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
                shipAnimator.SetFloat("Cruise", Converted);
                oceanAnimator.SetFloat("Wave", Converted);
            }
            Debug.Log(Converted);
            Converted = end;
            shipAnimator.SetFloat("Cruise", Converted);
            oceanAnimator.SetFloat("Wave", Converted);
        }
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

  


