using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using TMPro;
using UnityEngine.SceneManagement;


public class SimControlerScripts : MonoBehaviour
{
    public int i = 0;
    public int z = 0;
    float Converted;
    float startdelay = 0.0f;
    float timeinterval = 1.0f;
    public ShowingOnScreen OnScreen;
    public UseData Data;
    public GameObject DataText;
    public GameObject blackOutSquare;
    public Animator blackOutAnimator;
    public GameObject sailboatGO;
    public Animator sailboatAnimator;
    public GameObject yachtGO;
    public Animator yachtAnimator;
    public GameObject shipGO;
    public Animator shipAnimator;
    public GameObject oceanGO;
    public Animator oceanAnimator;
    public GameObject creditsText;
    public RectTransform creditPos;
    public GameObject directionalLight;

    // Start is called before the first frame update
    void Start()
    {
        //  Sailboatanom = Sailboat.GetComponent<Animator>();
        //Data = GameObject.Find("UseDataObject");
        oceanAnimator.Play("OceanWaves", 0, 0f);
        sailboatAnimator.Play("Sailboat", 0, 0f);
        yachtAnimator.Play("Yacht", 0, 0f);
        shipAnimator.Play("CruiseShip", 0, 0f);
        sailboatGO.SetActive(true);
        yachtGO.SetActive(false);
        shipGO.SetActive(false);
        InvokeRepeating("loopFiltering", startdelay, timeinterval);
        StartCoroutine(FadeBlackOutSquare(false, 1.0f));

    }

    void loopFiltering()
    {

        if(z != 3)
        {
            //StartCoroutine(FadeBlackOutSquare(false,1.0f));
        }
       
        if (i == 36)
        {
            i = 0;
            z++;
            Debug.Log("Fade Here.");
            StartCoroutine(FadeBlackOutSquare(true,1.0f));
            
 //           blackOutAnimator.SetBool("Black", true);

/*
            oceanAnimator.Play("OceanWaves", 0, 0f);
            if (z == 0)
            {
                sailboatGO.SetActive(true);
                yachtGO.SetActive(false);
                shipGO.SetActive(false);
                sailboatAnimator.Play("Sailboat", 0, 0f);
 //               blackOutAnimator.SetBool("Black", false);
            }
            if (z == 1)
            {
                sailboatGO.SetActive(false);
                yachtGO.SetActive(true);
                shipGO.SetActive(false);
                yachtAnimator.Play("Yacht", 0, 0f);
//                blackOutAnimator.SetBool("Black", false);
            }
            if (z == 2)
            {
                sailboatGO.SetActive(false);
                yachtGO.SetActive(false);
                shipGO.SetActive(true);
                shipAnimator.Play("CruiseShip", 0, 0f);
 //               blackOutAnimator.SetBool("Black", false);
            }
            
         */
            
        }
      
        if (z == 0)
        { 
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
            OnScreen.Setyear((i + 1985).ToString());
            OnScreen.SetLoc("United States");
            float v1 = shipAnimator.GetFloat("Cruise");
            OnScreen.SetCrime(Data.Getdata(i, "United_States"));
            float v2 = float.Parse(Data.Getdata(i, "UnitedStatesConverted"));
            //  Converted = float.Parse(Data.Getdata(i, "UnitedStatesConverted"));
            //Debug.Log("The UnitedStatesConverted is: " + Converted);

            StartCoroutine(ChangeVal(v1, v2, timeinterval));
        }
        else if (z == 3)
        {
            //creditPos.position = new Vector3(0, Credits.textPosBegin, 0);
            DataText.SetActive(false);
            creditsText.SetActive(true);
            if (creditsText.transform.position.y >= Credits.boundaryTextEnd)
            {
                i = 35;
                Debug.Log("Credits Ended");
                //creditPos.position = new Vector3(0, Credits.textPosBegin, 0);
                creditsText.SetActive(false);
            }
        }

        else
        {
            i = 0;
            z = 0;// Quit Is Not Working

            SceneManager.LoadScene("SampleScene");
            //           blackOutAnimator.SetBool("Black", false);
        }
        i++;
 //       Debug.Log(i);
    }

    public IEnumerator ChangeVal(float start, float end, float duration)
    {
        //Debug.Log("Blend Started");
        float elapsed = 0.0f;
        float sunConvert = 0.0f;
        if (z == 0) 
        { 
            while (elapsed < duration)
            {
                Converted = Mathf.Lerp(start, end, elapsed / duration);
                sunConvert = Mathf.Lerp(((float)i/36)*220f, ((float)(i+1)/36)*220f, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
                Quaternion sunRot = Quaternion.Euler(-20 + sunConvert, 0, 0);
                Debug.Log(sunConvert);
                directionalLight.transform.rotation = sunRot;
                sailboatAnimator.SetFloat("Sail", Converted);
                oceanAnimator.SetFloat("Wave", Converted);
            }
            //Debug.Log(Converted);
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
                sunConvert = Mathf.Lerp(((float)i / 36) * 220f, ((float)(i + 1) / 36) * 220f, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
                Quaternion sunRot = Quaternion.Euler(-20 + sunConvert, 0, 0);
                Debug.Log(sunConvert);
                directionalLight.transform.rotation = sunRot;
                yachtAnimator.SetFloat("Yacht", Converted);
                oceanAnimator.SetFloat("Wave", Converted);
                //Debug.Log("Yacht: " + yachtAnimator.GetFloat("Yacht"));
                //Debug.Log("Wave: " + oceanAnimator.GetFloat("Wave"));
            }
           //Debug.Log(Converted);
            Converted = end;
            yachtAnimator.SetFloat("Yacht", Converted);
            oceanAnimator.SetFloat("Wave", Converted);
        }

        if (z == 2)
        {
            while (elapsed < duration)
            {
                Converted = Mathf.Lerp(start, end, elapsed / duration);
                sunConvert = Mathf.Lerp(((float)i / 36) * 220f, ((float)(i + 1) / 36) * 220f, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
                Quaternion sunRot = Quaternion.Euler(-20 + sunConvert, 0, 0);
                Debug.Log(sunConvert);
                directionalLight.transform.rotation = sunRot;
                shipAnimator.SetFloat("Cruise", Converted);
                oceanAnimator.SetFloat("Wave", Converted);
            }
            //Debug.Log(Converted);
            Converted = end;
            shipAnimator.SetFloat("Cruise", Converted);
            oceanAnimator.SetFloat("Wave", Converted);
        }
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack, float fadeSpeed)
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
                //Debug.Log("Fade In Test: "+ blackOutSquare.GetComponent<Image>().color.a);
                yield return null;
            }
            //Debug.Log("Fade Over.");

            oceanAnimator.Play("OceanWaves", 0, 0f);
            if (z == 0)
            {
                sailboatGO.SetActive(true);
                yachtGO.SetActive(false);
                shipGO.SetActive(false);
                sailboatAnimator.Play("Sailboat", 0, 0f);
                //               blackOutAnimator.SetBool("Black", false);
            }
            if (z == 1)
            {
                sailboatGO.SetActive(false);
                yachtGO.SetActive(true);
                shipGO.SetActive(false);
                yachtAnimator.Play("Yacht", 0, 0f);
                //                blackOutAnimator.SetBool("Black", false);
            }
            if (z == 2)
            {
                sailboatGO.SetActive(false);
                yachtGO.SetActive(false);
                shipGO.SetActive(true);
                shipAnimator.Play("CruiseShip", 0, 0f);
                //               blackOutAnimator.SetBool("Black", false);
            }

            if (z != 3)
            {
                StartCoroutine(FadeBlackOutSquare(false, 1.0f));
            }

            
        }

        else
        {
            
            while (blackOutSquare.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                //Debug.Log("Fade Out Test: " + blackOutSquare.GetComponent<Image>().color.a);
                yield return null;
            }
            //Debug.Log("Unfade Over.");
        }
    }

}

  


