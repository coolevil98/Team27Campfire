﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class IntroText : MonoBehaviour
{
    #region Variables
    public TMP_Text introText;
    public List<string> introTextCollection = new List<string>();
    public float textDisplayTime;
    private float storeTime;
    private int currentText = 0;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        storeTime = textDisplayTime;
        introText.text = introTextCollection[currentText];
    }

    // Update is called once per frame
    void Update()
    {
        textDisplayTime -= Time.deltaTime;
        if(textDisplayTime <= - 0)
        {
            currentText++;
            introText.text = introTextCollection[currentText];
            textDisplayTime = storeTime;
            //if list reaches end then after one more timer destory the canvas to reduce load
        }
    }
}