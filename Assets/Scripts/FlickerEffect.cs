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

    public Vector2[] speedMults = new Vector2[2];//x for speed, y for time
    private int speedsIndex;
    private float timeDif;

    // Start is called before the first frame update
    void Start()
    {
        ball.SetActive(false);

        timeDif = speedMults[speedsIndex + 1].y - speedMults[speedsIndex].y;
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
        }
        print(speed);
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
        speedMult = speedMults[speedsIndex - 1].x + (speedMults[speedsIndex].x - speedMults[speedsIndex - 1].x) * (timer - speedMults[speedsIndex - 1].y) / timeDif;
        if (timer >= speedMults[speedsIndex].y)
        {
            timeDif = speedMults[speedsIndex].y - speedMults[speedsIndex - 1].y;
            speedsIndex++;
        }
    }
}
