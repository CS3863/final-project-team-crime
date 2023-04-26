using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UseData : MonoBehaviour
{
    List<Dictionary<string, object>> data;

    internal string Getdata(int row, string name)
    {
        data = CSVReader.Read("TotalCrimeData");
        //print("xco2 " + data[row][name]);
        return ((data[row][name]).ToString());
    }



}