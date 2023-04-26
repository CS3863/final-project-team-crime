using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
<<<<<<< Updated upstream
=======
using UnityEngine.UI;
>>>>>>> Stashed changes


public class SimControlerScripts : MonoBehaviour
{
    int i = 0;
<<<<<<< Updated upstream
    float timeinterval = 0.2f;
    float startdelay = 0.0f;

    public ShowingOnScreen OnScreen;
    // Start is called before the first frame update
    void Start()
    {

        // years.SetText("Tesing");

        //SimControlerScripts.Get
        //Showing.ToStringShowingYears
        //Showing.SetText("testing251618484");


        //Start the coroutine we define below named ExampleCoroutine.




        InvokeRepeating("loopInfo", startdelay, timeinterval);



    }

    void loopInfo()
    {
        if(i == 36)
        {
            i = 0;
        }
        OnScreen.Setyear((i+1985).ToString());
        OnScreen.SetLoc("TULSA");
        OnScreen.SetCrime("25");
   
        i++;


    }

=======
    int z = 0;

    float startdelay = 0.0f;
    float timeinterval = 2f;
    public ShowingOnScreen OnScreen;
    public UseData Data;
    public GameObject blackOutSquare;
    public Animation sun;
 
    void Awake()
    {
        sun = GameObject.Find("Sun").GetComponent<Animation>(); //find the Sun game object animation 
    }


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
            OnScreen.SetLoc("United States");
            OnScreen.SetCrime(Data.Getdata(i, "United_States"));
            sun.Play("DayNightCycle");
         
           
        }
        else if (z == 1)
        {
            OnScreen.Setyear((i + 1985).ToString());
            OnScreen.SetLoc("Oklahoma");
            OnScreen.SetCrime(Data.Getdata(i, "Oklahoma"));
            sun.Play("DayNightCycle");
        }
        else if (z == 2)
        {
            OnScreen.Setyear((i + 1985).ToString());
            OnScreen.SetLoc("Tulsa");
            OnScreen.SetCrime(Data.Getdata(i, "Tulsa"));
            sun.Play("DayNightCycle");
        }
        else
        {
            Application.Quit();
        }
       
        i++;
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, int fadeSpeed = 15)
    {
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while(blackOutSquare.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;

            }
        } else
        {
            while (blackOutSquare.GetComponent <Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r,objectColor.g,objectColor.b,fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }

        }
    }
>>>>>>> Stashed changes

    // Update is called once per frame
    void Update()
    {


    }
<<<<<<< Updated upstream
=======

    
>>>>>>> Stashed changes
}
   
