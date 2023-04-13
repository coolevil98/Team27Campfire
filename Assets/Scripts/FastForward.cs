using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;

public class FastForward : MonoBehaviour
{
    public float ffSpeed = 19;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (VRDevice.Device.PrimaryInputDevice.GetButton(VRButton.Seconday))
        {
            Time.timeScale = 1 + (ffSpeed * VRDevice.Device.PrimaryInputDevice.GetAxis2D(VRAxis.One).y);
        }
        else
        {
            Time.timeScale = 1 + (ffSpeed * Input.GetAxis("Vertical"));
        }
        
    }
}
