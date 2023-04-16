using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumOfPart : MonoBehaviour
{
    public ParticleSystem fireParticles;
    public float emRate;
    public float timeToChangeInSec;
    public float newRate1;
    public float newRate2;
    public float newRate3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fireParticlesEmission());
    }

    // Update is called once per frame
    void Update()
    {
        var emission = fireParticles.emission;
        emission.rateOverTime = emRate;
    }

    IEnumerator fireParticlesEmission()
    {
        //the 60 is for the intro
        yield return new WaitForSeconds(60 + timeToChangeInSec);
        emRate = newRate1;
        Debug.Log("changed");
        yield return new WaitForSeconds(timeToChangeInSec);
        emRate = newRate2;
        Debug.Log("changed2");
        yield return new WaitForSeconds(timeToChangeInSec);
        emRate = newRate3;
        Debug.Log("changed3");
    }
}
