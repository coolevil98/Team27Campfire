using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFire : MonoBehaviour
{
    //Unused script. Used to instantiate random black circles when pressing 'a', similar to pink rain.
    public GameObject[] FirePrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            int randomIndex = Random.Range(0, FirePrefab.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-5.8f, 6), Random.Range(-1, 4), 8.88f);

            Instantiate(FirePrefab[randomIndex], randomSpawnPosition, Quaternion.identity);
        }
    }
}