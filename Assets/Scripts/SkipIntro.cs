using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;

public class SkipIntro : MonoBehaviour
{
    public ParticleSystem lightSystem;
    public GameObject fire;
    public GameObject introCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (VRDevice.Device.PrimaryInputDevice.GetButton(VRButton.Four) || Input.GetKeyDown("space"))
        {
            introCanvas.SetActive(false);
            fire.SetActive(true);
            lightSystem.Play();
            FindObjectOfType<SSoundManager>().Play("fireplaceholder");
            FindObjectOfType<SSoundManager>().Play("oceanplaceholder");
        }
    }
}
