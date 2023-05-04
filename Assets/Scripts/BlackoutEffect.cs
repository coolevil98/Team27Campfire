using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackoutEffect : MonoBehaviour
{
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        wall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ActiviteWall();
        }
    }

    public void ActiviteWall()
    {
        wall.SetActive(true);
        StartCoroutine(makeInvisible());
    }
    IEnumerator makeInvisible()
    {
        yield return new WaitForSeconds(2);
        wall.SetActive(false);
    }
}
