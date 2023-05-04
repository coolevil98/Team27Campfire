using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class BlackoutMoving : MonoBehaviour
{
    #region Variables
    [Header("Object")]
    public GameObject movingWall;
    [Header ("Start and End positions")]
    public Vector3 startMarker;
    public Vector3 endMarker;

    private float journeyLength;
    private float startTime;

    private bool moving = false;
    [Header("Speed")]
    public float speed = 1.0F;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        journeyLength = Vector3.Distance(startMarker, endMarker);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.O))
        {
            StartMove();
        }
        if(moving)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;
            movingWall.transform.position = Vector3.Lerp(startMarker, endMarker, fractionOfJourney);
            if(fractionOfJourney>=1)
            {
                moving = false;
            }
        }
    }

    public void StartMove()
    {
        moving = true;
        startTime = Time.time;
    }
}
