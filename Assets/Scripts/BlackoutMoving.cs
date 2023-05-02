using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BlackoutMoving : MonoBehaviour
{
    public GameObject movingWall;
    //this will move the panning object across the screen
    //such as from right to left
    //could use transform translate
    //on start put it back to the beginning position

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            movingWall.transform.position= Vector3.Lerp(new Vector3(10,0,3), new Vector3(-10, 0, 3), 0.2f);
            Debug.Log("hi");
        }
    }
}
