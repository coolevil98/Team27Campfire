using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class IntroText : MonoBehaviour
{
    #region Variables
    public TMP_Text introText;
    public List<string> introTextCollection = new List<string>();
    public float textDisplayTime;
    private float storeTime;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        storeTime = textDisplayTime;
    }

    // Update is called once per frame
    void Update()
    {
        storeTime-=Time.deltaTime;
        if(storeTime <=- 0)
        {
            //change text go up one for the list
            //if list reaches end then after one more timer destory the canvas to reduce load
        }
    }
}
