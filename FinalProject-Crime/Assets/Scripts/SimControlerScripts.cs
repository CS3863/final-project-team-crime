using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class SimControlerScripts : MonoBehaviour
{
    int i = 0;
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


    // Update is called once per frame
    void Update()
    {


    }
}
   
