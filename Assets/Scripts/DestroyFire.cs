using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFire : MonoBehaviour
{
    //unused script, used with RandomFire to delete instantiated sprites
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
