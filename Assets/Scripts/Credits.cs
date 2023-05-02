using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class Credits : MonoBehaviour
{
    float speed = 50.0f;
    static public float textPosBegin = -395.0f;
    static public float boundaryTextEnd = 1500.0f;

    RectTransform myGorectTransform;
    [SerializeField]
    TextMeshProUGUI mainText;


    [SerializeField]
    //bool isLooping = false;
    // Start is called before the first frame update
    void Start()
    {
        myGorectTransform = gameObject.GetComponent<RectTransform>();
        StartCoroutine(AutoScrollText());
    }
    IEnumerator AutoScrollText()
    {
        while (myGorectTransform.localPosition.y < boundaryTextEnd)
        {
            myGorectTransform.Translate(Vector3.up * speed * Time.deltaTime);
            yield return null;
        }
    }
} 
