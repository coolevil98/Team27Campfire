﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;

public class IntroText : MonoBehaviour
{
    #region Variables
    public TMP_Text introText;
    public GameObject textHolder;
    public List<string> introTextCollection = new List<string>();
    public float textDisplayTime;
    private float storeTime;
    private int currentText = 0;
    private bool fadeOccur=true;

    //
    //assign 
    [Tooltip("Set particle system to not play on awake")]
    public ParticleSystem lightSystem;
    public GameObject fire;
    public GameObject testing;
    #endregion

    void Awake()
    {
        fire.SetActive(false);
    }

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
        if (fadeOccur && textDisplayTime <= 2)
        {
            introText.CrossFadeAlpha(0f, 2f, false);
            fadeOccur = false;
        }
        if (textDisplayTime <=  0)
        {
            currentText++;
            if (currentText >= introTextCollection.Count)
            {
                fire.SetActive(true);
                lightSystem.GetComponent<DimFire>().FireStarted();
                lightSystem.Play();
                Destroy(textHolder);
            }
            if (currentText < introTextCollection.Count)
            {
                introText.text = introTextCollection[currentText];
                textDisplayTime = storeTime;
                introText.CrossFadeAlpha(1f, 1f, false);
                fadeOccur = true;
            }
        }
    }
}
