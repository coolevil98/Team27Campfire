using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSize : MonoBehaviour
{
    public GameObject ball;
    public float minSize;
    public float maxSize;
    public float cooldown = 5;
    public float changeTimer = 1;
    private float timer;
    private Vector3 newlocalSize;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        newlocalSize = ball.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //check if ball is active
        if(ball.activeSelf == true)
        {
            // change circle if timer is 0 if not then timer minus
            if (timer <= 0)
            {
                NewSize();
            }
            else
            {
                timer = timer - 1 * Time.deltaTime;
            }
        }
        ChangeSize();
        
    }

    //change size of the ball
    public void NewSize()
    {
        newlocalSize.x = Random.Range(minSize, maxSize);
        newlocalSize.y = Random.Range(minSize, maxSize);
        timer = cooldown;
    }
    //change size of the ball
    public void ChangeSize()
    {
        ball.transform.localScale = Vector3.SmoothDamp(ball.transform.localScale, newlocalSize, ref velocity, changeTimer);
    }
}
