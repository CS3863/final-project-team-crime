using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using System;

//int mastervalue = 0;
public class ShowingOnScreen : MonoBehaviour
{
    string year;
    string loc;
    string crime;

    public TMP_Text canvasText;

    // Start is called before the first frame update
    void Start()
    {
        //canvasText.text = "TESTING THIS";
    }

    // Update is called once per frame
    void Update()
    {
        canvasText.text = year + " \n" + loc + "\nCrime rate per 100,000 people: " + crime;
    }

    internal void Setyear(string year)
    {
        this.year = year;
    }
    internal void SetLoc(string loc)
    {

        this.loc = loc;
    }
    internal void SetCrime(string crime)
    {

        this.crime = crime;

    }


    /* void setMaterValue(int master)
{
    mastervalue = master;

}*/


}