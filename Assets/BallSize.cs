using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSize : MonoBehaviour
{
    public GameObject ball;
    public float minSize;
    public float maxSize;
    public float cooldown;
    private float timer;
    private Vector3 localSize;
    private Vector3 newLocalSize;
    public float speedChange;
    void Start()
    {
        localSize = ball.transform.localScale;
    }
    // Update is called once per frame
    void Update()
    {
        if(ball.activeSelf == true)
        {
            if (timer <= 0)
            {  
                ChangeSize();
            }
            else
            {
                //Debug.Log(timer);
                timer = timer - 1 * Time.deltaTime;
            }
        }
        
        
    }

    public void ChangeSize()
    {
        Debug.Log("haa");
        localSize.x = Random.Range(minSize, maxSize);
        localSize.y = Random.Range(minSize, maxSize);
        newLocalSize = new Vector3(newLocalSize.x, newLocalSize.y, 1f);
        //localSize = Vector3.Lerp(localSize, newLocalSize, speedChange * Time.deltaTime);
        ball.transform.localScale = localSize;
        timer = cooldown;
    }
}
