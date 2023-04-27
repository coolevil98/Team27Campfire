using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerEffect : MonoBehaviour
{
    public float leftMax;
    public float rightMax;
    public DimFire timer;
    public GameObject ball;
    private float currentAngle;
    public float speed;
    private bool turnOn = false;
    // Start is called before the first frame update
    void Start()
    {
        ball.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        currentAngle = gameObject.transform.rotation.z;
        if(timer.getTimer > 0)
        {
            ball.SetActive(true);
            turnOn = true;
        }
        if(turnOn == true)
        {
            RotateCircle();
        }
        

    }

    public void RotateCircle()
    {
        transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * 60, 180)-90);
    }

    
}
