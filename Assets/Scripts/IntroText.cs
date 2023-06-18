using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;

public class IntroText : MonoBehaviour
{
    #region Variables
    [Header("Text")]
    public TMP_Text introText;
    public GameObject textHolder;
    [Tooltip ("List of text used for introduction canvas")]
    public List<string> introTextCollection = new List<string>();
    [Tooltip("List of times in seconds for each text in introTextCollection")]
    public List<float> introTextLength = new List<float>();
    private float textDisplayTime; //current time till next text
    private int currentText = 0; //Number for current text is displayed
    private bool fadeOccur = true; //enable and disable fade of text

    [Header("Fire")]
    [Tooltip("Set particle system to not play on awake")]
    public ParticleSystem lightSystem;
    public GameObject fire;
    #endregion

    void Awake()
    {
        fire.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        introText.text = introTextCollection[currentText];
        textDisplayTime = introTextLength[currentText];
    }

    // Update is called once per frame
    void Update()
    {
        textDisplayTime -= Time.deltaTime;
        if (fadeOccur && textDisplayTime <= 2)
        {
            introText.CrossFadeAlpha(0f, 2f, false);
            fadeOccur = false;
        }
        if (textDisplayTime <=  0)
        {
            currentText++;
            if(currentText == 1 && textDisplayTime <= 6f)
            {
                //This method allows audio clips to be played outside of the SSoundManager script
                FindObjectOfType<SSoundManager>().Play("laugh1");
            }

            if(currentText == 4 && textDisplayTime <= 6f)
            {
                FindObjectOfType<SSoundManager>().Play("laugh2");
            }
            if (currentText >= introTextCollection.Count)
            {
                fire.SetActive(true);
                lightSystem.GetComponent<DimFire>().FireStarted();
                lightSystem.Play();
                Destroy(textHolder);
                //This method allows audio clips to fade outside of the SSoundManager script
                //If the intro text has finished, increase volume of main tracks by fading
                FindObjectOfType<SSoundManager>().FadeCall("fireplaceholder", 0.005f, 1f);
                FindObjectOfType<SSoundManager>().FadeCall("oceanplaceholder", 0.005f, 0.3f);
                FindObjectOfType<SSoundManager>().FadeCall("windplaceholder", 0.005f, 0.2f);
            }
            if (currentText < introTextCollection.Count)
            {
                introText.text = introTextCollection[currentText];
                textDisplayTime = introTextLength[currentText];
                introText.CrossFadeAlpha(1f, 1f, false);
                fadeOccur = true;
            }
        }
    }
}
