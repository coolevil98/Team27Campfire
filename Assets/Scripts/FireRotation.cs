using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRotation : MonoBehaviour
{
    public DimFire timer;
    public GameObject ball;
    public float speed;
    public float minSpeedTimer;
    public float maxSpeedTimer;
    private float cooldown;
    public float minSpeed;
    public float maxSpeed;
    private bool turnOn = false;
    public float degree;
    public float currentAngle;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = Random.Range(minSpeedTimer, maxSpeedTimer);
        currentAngle = -180;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer.getTimer > 0)
        {
            turnOn = true;
        }
        if (turnOn == true)
        {
            if(cooldown <= 0)
            {
                cooldown = Random.Range(minSpeedTimer, maxSpeedTimer);
                speed = Random.Range(minSpeed, maxSpeed);
            }
            else
            {
                cooldown = cooldown - 1 * Time.deltaTime;
            }
            newRotateCircle();
        }


    }

    public void RotateCircle()
    {    
        transform.localEulerAngles = new Vector3(Mathf.PingPong(Time.time * speed, degree) -180,90, 90);
    }
    public void newRotateCircle()
    {
        if (currentAngle >= 0)
        {
            speed = speed * -1;
        }
        else if (currentAngle <= -180)
        {
            speed = speed * -1;
        }
        transform.localEulerAngles = new Vector3(currentAngle = currentAngle + speed * Time.deltaTime, 90, 90);
    }
}
