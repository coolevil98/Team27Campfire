using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerEffect : MonoBehaviour
{
    public DimFire timer;
    public GameObject ball;
    public int speed = 60; //Mathf.PingPong was buggy when slowly incrementing through a float
    private bool turnOn = false;
    public float degree;

    public Vector2[] speeds = new Vector2[2];//x for speed, y for time
    private int speedsIndex;
    private float speedsDif;

    // Start is called before the first frame update
    void Start()
    {
        ball.SetActive(false);

        speedsDif = speeds[speedsIndex + 1].y - speeds[speedsIndex].y;
        speedsIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer.getTimer > 0)
        {
            ball.SetActive(true);
            turnOn = true;
        }
        if(turnOn == true)
        {
            if (speedsIndex < speeds.Length)
            {
                Speed();
            }
            RotateCircle();
        }
    }

    public void RotateCircle()
    {
        transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * speed, degree)-90);
    }

    public void Speed()
    {
        speed = Mathf.RoundToInt(speeds[speedsIndex - 1].x + (speeds[speedsIndex].x - speeds[speedsIndex - 1].x) * (timer.getTimer - speeds[speedsIndex - 1].y) / speedsDif);
        if (timer.getTimer >= speeds[speedsIndex].y)
        {
            speedsIndex++;
            if (speedsIndex < speeds.Length)
            {
                speedsDif = speeds[speedsIndex].y - speeds[speedsIndex - 1].y;
            }
        }
    }
}
