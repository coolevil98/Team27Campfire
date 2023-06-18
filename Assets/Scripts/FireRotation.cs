using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRotation : MonoBehaviour
{
    public DimFire timer;
    public float speed;
    public float minSpeedTimer;
    public float maxSpeedTimer;
    private float cooldown;
    public float minSpeed;
    public float maxSpeed;
    private bool turnOn = false;
    public float currentAngle;
    private int dir = 1;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = Random.Range(minSpeedTimer, maxSpeedTimer);
        currentAngle = -90;
    }

    // Update is called once per frame
    void Update()
    {
        //Turn the fire rotation on if intro is finish
        if (timer.getTimer > 0)
        {
            turnOn = true;
        }

        if (turnOn == true)
        {
            //fire rotation
            if(cooldown <= 0)
            {
                //change speed for fire on random times
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

    //Rotate circle function
    public void newRotateCircle()
    {
        if (currentAngle >= 0)
        {
            dir = -1;
        }
        else if (currentAngle <= -180)
        {
            dir = 1;
        }
        transform.localEulerAngles = new Vector3(currentAngle = currentAngle + speed * dir * Time.deltaTime, 90, 0);
    }
}
