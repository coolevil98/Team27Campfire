using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerEffect : MonoBehaviour
{
    public DimFire timerScript;
    private float timer;
    private float pingPongTimer;
    public GameObject ball;
    public float speedMult = 1;
    public float speed = 1;
    private bool turnOn = false;
    public float degree;

    public Vector3[] speedMults = new Vector3[2];//x for min speed, y for max speed, z for time
    public int randTimer = 3; //number of seconds to calculate a random speed
    private int randTimes = 1;
    private float minSpeedMult;
    private float maxSpeedMult;
    private int speedsIndex;
    private float timeDif;

    // Start is called before the first frame update
    void Start()
    {
        ball.SetActive(false);

        timeDif = speedMults[speedsIndex + 1].z - speedMults[speedsIndex].z;
        speedsIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timerScript.getTimer;
        if (timer > 0)
        {
            ball.SetActive(true);
            turnOn = true;
        }
        if(turnOn == true)
        {
            if (speedsIndex < speedMults.Length)
            {
                Speed();
            }
            RotateCircle();
            SetSpeedMult();
        }
    }

    void FixedUpdate()
    {
        pingPongTimer += speed * speedMult;
    }

    public void RotateCircle()
    {
        transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(pingPongTimer, degree)-90);
    }

    public void Speed()
    {
        minSpeedMult = speedMults[speedsIndex - 1].x + (speedMults[speedsIndex].x - speedMults[speedsIndex - 1].x) * (timer - speedMults[speedsIndex - 1].z) / timeDif;
        maxSpeedMult = speedMults[speedsIndex - 1].y + (speedMults[speedsIndex].y - speedMults[speedsIndex - 1].y) * (timer - speedMults[speedsIndex - 1].z) / timeDif;
        if (timer >= speedMults[speedsIndex].z)
        {
            timeDif = speedMults[speedsIndex].z - speedMults[speedsIndex - 1].z;
            speedsIndex++;
        }
    }

    public void SetSpeedMult()
    {
        if (timer / randTimer > randTimes)
        {
            randTimes++;
            speedMult = Random.Range(minSpeedMult, maxSpeedMult);
            print(speedMult);
        }
    }
}
