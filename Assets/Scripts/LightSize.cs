using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.SDK.Core;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;

public class LightSize : MonoBehaviour
{
    public float cSpeed = 0.3f;
    public GameObject fire;
    public GameObject inner;
    public GameObject outer;
    private Color cOfInner;
    private Color cOfOuter;
    public float xySpeed = 0.5f;
    private float xSizeOfFire = 1;
    private float ySizeOfFire = 1;

    void Start()
    {
        cOfInner = inner.GetComponent<SpriteRenderer>().color;
        cOfOuter = outer.GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        cOfInner.a += VRDevice.Device.PrimaryInputDevice.GetAxis2D(VRAxis.One).y * cSpeed * Time.deltaTime;
        cOfInner.a = Mathf.Clamp(cOfInner.a, 0, 255);
        cOfOuter.a += VRDevice.Device.PrimaryInputDevice.GetAxis2D(VRAxis.One).y * cSpeed * Time.deltaTime;
        cOfOuter.a = Mathf.Clamp(cOfOuter.a, 0, 255);
        inner.GetComponent<SpriteRenderer>().color = cOfInner;
        outer.GetComponent<SpriteRenderer>().color = cOfOuter;
        xSizeOfFire += VRDevice.Device.SecondaryInputDevice.GetAxis2D(VRAxis.One).x * xySpeed * Time.deltaTime;
        xSizeOfFire = Mathf.Clamp(xSizeOfFire, 0, 2);
        ySizeOfFire += VRDevice.Device.SecondaryInputDevice.GetAxis2D(VRAxis.One).y * xySpeed * Time.deltaTime;
        ySizeOfFire = Mathf.Clamp(ySizeOfFire, 0, 2);
        fire.transform.localScale = new Vector3(xSizeOfFire, ySizeOfFire, 0);
    }
}
