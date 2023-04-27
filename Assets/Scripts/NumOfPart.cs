using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumOfPart : MonoBehaviour
{
    public DimFire timer;
    public ParticleSystem fireParticles;
    public float emRate;
    public float timeToChangeInSec;
    public float newRate1;
    public float newRate2;
    public float newRate3;
    public float logRate;
    public float timeToLog;

    private float fireTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
        //StartCoroutine(fireParticlesEmission());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timer.getTimer);
        var emission = fireParticles.emission;
        emission.rateOverTime = emRate;
        FireParticleWithTimer();
    }

    IEnumerator fireParticlesEmission()
    {
        //the 60 is for the intro
        
        yield return new WaitForSeconds(64 + timeToChangeInSec);
        emRate = newRate1;
        Debug.Log("changed");
        yield return new WaitForSeconds(timeToChangeInSec);
        emRate = newRate2;
        Debug.Log("changed2");
        yield return new WaitForSeconds(timeToChangeInSec);
        emRate = newRate3;
        Debug.Log("changed3");
        yield return new WaitForSeconds(10 + timeToLog);
        emRate = logRate;
        Debug.Log("logchanged");
        yield return new WaitForSeconds(timeToChangeInSec);
        emRate = newRate1;
        Debug.Log("changed4");
    }

    public void FireParticleWithTimer()
    {
        
        if(timer.getTimer >= 10)
        {
            emRate = newRate1;
            Debug.Log("c1");
        }
        if(timer.getTimer >= 20)
        {
            emRate = newRate2;
            Debug.Log("c2");
        }
        if(timer.getTimer >= 30)
        {
            emRate = newRate3;
            Debug.Log("c3");
        }
    }
}
