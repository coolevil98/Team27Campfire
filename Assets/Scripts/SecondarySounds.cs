using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondarySounds : MonoBehaviour
{
    // Start is called before the first frame update
    public float minTimeBetweenSounds;
    public float maxTimeBetweenSounds;
    private float currentTimeLeft;
    void Start()
    {
        currentTimeLeft= Random.Range(minTimeBetweenSounds, maxTimeBetweenSounds);
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeLeft-= Time.deltaTime;
        if(currentTimeLeft<=0)
        {
            //play sound
            currentTimeLeft= Random.Range(minTimeBetweenSounds, maxTimeBetweenSounds);
        }
    }
}
