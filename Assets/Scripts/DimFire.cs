using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimFire : MonoBehaviour
{
    public Color emberColour = new Color(1.0f, 0.6f, 0.0f, 1.0f);
    private Color spiteColour;

    private ParticleSystem emberParticles;
    public float minVPercentOfMaxV = 0.33333333f;
    public Vector2[] velocities = new Vector2[2]; //x for velocity, y for time
    private int velocitiesIndex;
    private float vel;
    private float velTimerDif;

    public Vector2[] alphas = new Vector2[2];//x for alpha, y for time
    private int alphasIndex;
    private float alpha;
    private float alphasDif;

    private float timer;
    public SpriteRenderer backgroundSprite;
    
    public float getTimer
    {
        get
        {
            return timer;
        }
    }

    private bool isFire = false;
    private bool fireStarted = false;

    
    void Start()
    {
        emberParticles = gameObject.GetComponent<ParticleSystem>();
        var main = emberParticles.main;
        main.startSpeed = new ParticleSystem.MinMaxCurve(velocities[velocitiesIndex].x * minVPercentOfMaxV, velocities[velocitiesIndex].x);
        main.startColor = emberColour;

        velTimerDif = velocities[velocitiesIndex + 1].y - velocities[velocitiesIndex].y;
        velocitiesIndex++;

        alphasDif = alphas[alphasIndex + 1].y - alphas[alphasIndex].y;
        alphasIndex++;

        spiteColour = backgroundSprite.color;
    }

    void Update()
    {
        //Timer that updates
        if (isFire)
        {
            timer += Time.deltaTime;
        }

        if (velocitiesIndex < velocities.Length)
        {
            Velocity();
        }

        if (alphasIndex < alphas.Length)
        {
            Transparency();
        }

        print(timer);
        //print(alpha);

        //system for determining what sound effect plays where. Once all the sound effects are at the right volume/right order, I might get rid of this and put all the sound effects
        //into one continuous audio file so we don't have to have 1 billion if statements
        if(timer >= 5.0f && timer <= 5.5f){
            FindObjectOfType<SSoundManager>().Play("Narration1");
        }

        if(timer >= 10.0f && timer <= 10.5f){
            FindObjectOfType<SSoundManager>().Play("bottledrink");
        }

        if(timer >= 12.0f && timer <= 12.5f){
            FindObjectOfType<SSoundManager>().Play("chairshuffle1");
        }

        if(timer >= 20.0f && timer <= 20.5f){
            FindObjectOfType<SSoundManager>().Play("Narration2");
        }

        if(timer >= 55.0f && timer <= 55.5f){
            FindObjectOfType<SSoundManager>().Play("murmur");
        }

        if(timer >= 75.0f && timer <= 75.5f){
            FindObjectOfType<SSoundManager>().Play("chairshuffle2");
        }

        if(timer >= 90.0f && timer <= 90.5f){
            FindObjectOfType<SSoundManager>().Play("chairshuffle3");
        }

        if(timer >= 180.0f && timer <= 180.5f){
            FindObjectOfType<SSoundManager>().Play("murmur2");
        }

        if(timer >= 200.0f && timer <= 200.5f){
            FindObjectOfType<SSoundManager>().Play("bottledrink2");
        }

        if(timer >= 222.0f && timer <= 222.5f){
            FindObjectOfType<SSoundManager>().Play("baglook");
        }

        if(timer >= 235.0f && timer <= 235.5f){
            FindObjectOfType<SSoundManager>().Play("cupfiddle");
        }

        if(timer >= 250.0f && timer <= 250.5f){
            FindObjectOfType<SSoundManager>().Play("murmur3");
        }

        if(timer >= 285.0f && timer <= 285.5f){
            FindObjectOfType<SSoundManager>().Play("murmur4");
        }

        if(timer >= 320.0f && timer <= 320.5f){
            FindObjectOfType<SSoundManager>().Play("Narration3");
        }

        if(timer >= 350.0f && timer <= 350.5f){
            FindObjectOfType<SSoundManager>().Play("tentzip");
        }

        if(timer >= 380.0f && timer <= 380.5f){
            FindObjectOfType<SSoundManager>().Play("sleepingbagroll");
        }

        if(timer >= 410.0f && timer <= 410.5f){
            FindObjectOfType<SSoundManager>().Play("sigh 1");
        }

        if(timer >= 415.0f && timer <= 415.5f){
            FindObjectOfType<SSoundManager>().Play("Narration4");
        }

        if(timer >= 440.0f && timer <= 440.5f){
            FindObjectOfType<SSoundManager>().Play("sleepingbagroll2");
        }

        if(timer >= 450.0f && timer <= 450.5f){
            FindObjectOfType<SSoundManager>().Play("murmur5");
        } //turn down slightly

        if(timer >= 470.0f && timer <= 470.5f){
            FindObjectOfType<SSoundManager>().Play("sleepingbagroll3");
        }

        if(timer >= 485.0f && timer <= 485.5f){
            FindObjectOfType<SSoundManager>().Play("Narration5");
        }

        if(timer >= 510.0f && timer <= 510.5f){
            FindObjectOfType<SSoundManager>().Play("tentzip2");
        } //turn down to same as tentzip 1

        if(timer >= 520.0f && timer <= 520.5f){
            FindObjectOfType<SSoundManager>().Play("bottledrink3");
        } //turn down

        if(timer >= 527.0f && timer <= 527.5f){
            FindObjectOfType<SSoundManager>().Play("sigh2");
        } //turn down

        if(timer >= 540.0f && timer <= 540.5f){
            FindObjectOfType<SSoundManager>().Play("cupfiddle3");
        }

        if(timer >= 550.0f && timer <= 550.5f){
            FindObjectOfType<SSoundManager>().Play("sleepingbagroll4");
        }

        if(timer >= 555.0f && timer <= 550.5f){
            FindObjectOfType<SSoundManager>().Play("sigh3");
        }

        if(timer >= 560.0f && timer <= 560.5f){
            FindObjectOfType<SSoundManager>().Play("sleepingbagroll5");
        }

        if(timer >= 575.0f && timer <= 575.5f){
            FindObjectOfType<SSoundManager>().Play("Narration6");
        }

        if(timer >= 600.0f && timer <= 600.5f){
            FindObjectOfType<SSoundManager>().Play("tentzip3");
        }



        /*Fire will dim 60 seconds after game starts
        if (timer >= 60.0f) 
        {
            Color orangeColor = new Color(1f, 0.5f, 0f, 1f);
            var colorOverLifetime = emberParticles.colorOverLifetime;
            Gradient gradient = new Gradient();
            GradientColorKey[] colorKeys = new GradientColorKey[2];
            colorKeys[0].color = Color.black;
            colorKeys[0].time = 0.0f;
            colorKeys[1].color = orangeColor;
            colorKeys[1].time = 1.0f;
            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
            alphaKeys[0].alpha = 1.0f;
            alphaKeys[0].time = 0.0f;
            alphaKeys[1].alpha = 0.0f;
            alphaKeys[1].time = 1.0f;
            gradient.SetKeys(colorKeys, alphaKeys);
            colorOverLifetime.color = gradient;
        }*/

    }

    public void Velocity()
    {
        vel = velocities[velocitiesIndex - 1].x + (velocities[velocitiesIndex].x - velocities[velocitiesIndex - 1].x) * (timer - velocities[velocitiesIndex - 1].y) / velTimerDif;
        if (timer >= velocities[velocitiesIndex].y)
        {
            velocitiesIndex++;
            if (velocitiesIndex < velocities.Length)
            {
                velTimerDif = velocities[velocitiesIndex].y - velocities[velocitiesIndex - 1].y;
            }
        }

        var main = emberParticles.main;
        main.startSpeed = new ParticleSystem.MinMaxCurve(vel * minVPercentOfMaxV, vel);
    }

    public void Transparency()
    {
        alpha = alphas[alphasIndex - 1].x + (alphas[alphasIndex].x - alphas[alphasIndex - 1].x) * (timer - alphas[alphasIndex - 1].y) / alphasDif;
        if (timer >= alphas[alphasIndex].y)
        {
            alphasIndex++;
            if (alphasIndex < alphas.Length)
            {
                alphasDif = alphas[alphasIndex].y - alphas[alphasIndex - 1].y;
            }
        }

        var main = emberParticles.main;
        emberColour.a = alpha;
        main.startColor = emberColour;

        spiteColour.a = alpha;
        backgroundSprite.color = spiteColour;
    }

    public void FireStarted()
    {
        isFire = true;
    }
}
