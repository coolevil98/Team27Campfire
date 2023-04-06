using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimFire : MonoBehaviour
{
    public ParticleSystem emberParticles;

    private float timer;
    
    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        //Timer that updates
        timer += Time.deltaTime;

        //Fire will dim 60 seconds after game starts
        if (timer >= 60.0f) 
        {
            Color orangeColor = new Color(1f, 0.5f, 0f, 1f);
            var colorOverLifetime = emberParticles.colorOverLifetime;
            Gradient gradient = new Gradient();
            GradientColorKey[] colorKeys = new GradientColorKey[2];
            colorKeys[0].color = Color.black;
            colorKeys[0].time = 0.0f;
            colorKeys[1].color = orangeColor;
            colorKeys[1].time = 1.0f;
            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
            alphaKeys[0].alpha = 1.0f;
            alphaKeys[0].time = 0.0f;
            alphaKeys[1].alpha = 0.0f;
            alphaKeys[1].time = 1.0f;
            gradient.SetKeys(colorKeys, alphaKeys);
            colorOverLifetime.color = gradient;
        }
    }
}
