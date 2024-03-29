﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFire : MonoBehaviour
{
    //Unused script. Used with RandomFire to delete instantiated sprites
    void Start()
    {
        StartCoroutine(Delete());
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(3);
        Object.Destroy(this.gameObject);
    }
}
