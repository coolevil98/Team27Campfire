using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour
{
    public GameObject Background;
    public DimFire timer;

    private void Update()
    {
        if (timer.getTimer > 0)
        {
            Background.SetActive(true);
        }
    }
}