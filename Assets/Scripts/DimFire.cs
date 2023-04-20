using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimFire : MonoBehaviour
{
    public Color emberColour = new Color(1.0f, 0.6f, 0.0f, 1.0f);
    
    private ParticleSystem emberParticles;
    public float minVPercentOfMaxV = 0.33333333f;
    public Vector2[] velocities = new Vector2[2];
    private int velocitiesIndex;
    private float vel;
    private float velTimerDif;

    public Vector2[] alphas = new Vector2[2];
    private int alphasIndex;
    private float alpha;
    private float alphasDif;

    private float timer;
  
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

        if(timer >= 10.0f && timer <= 10.5f){
            FindObjectOfType<SSoundManager>().Play("Narration1");
        }

        if(timer >= 30.0f && timer <= 30.5f){
            FindObjectOfType<SSoundManager>().Play("Narration2");
        }

        if(timer >= 120.0f && timer <= 120.5f){
            FindObjectOfType<SSoundManager>().Play("Narration3");
        }

        if(timer >= 150.0f && timer <= 150.5f){
            FindObjectOfType<SSoundManager>().Play("Narration4");
        }

        if(timer >= 200.0f && timer <= 200.5f){
            FindObjectOfType<SSoundManager>().Play("Narration5");
        }

        if(timer >= 250.0f && timer <= 250.5f){
            FindObjectOfType<SSoundManager>().Play("Narration6");
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
            velTimerDif = velocities[velocitiesIndex].y - velocities[velocitiesIndex - 1].y;
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
            alphasDif = alphas[alphasIndex].y - alphas[alphasIndex - 1].y;
        }

        var main = emberParticles.main;
        emberColour.a = alpha;
        main.startColor = emberColour;
    }

    public void FireStarted()
    {
        isFire = true;
    }
}
