using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityTheSecondScript : MonoBehaviour
{
    
    public CircleCollider2D areaOfInfluence;
    public CircleCollider2D deathZoneCollider;
    public float amountOfGravity;
    public float massOfPlanet;
    public float distanceFromPlanet;
    public MoonJuice moonJuice;
    public float moonTimer;
    public Text restartText;
    public Color originalColor;
    public float fadeOutTime = 1f;
    //if you expect this to be an accurate calculation of mass and gravity then you would be very wrong

    void Start()
    {
        moonJuice = FindObjectOfType<MoonJuice>();
        originalColor = Color.white;
        restartText = GameObject.Find("RestartText").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            moonTimer = 0f;
        }
    }
    void FixedUpdate()
    {
        MoonShotController[] moonsArray = FindObjectsOfType<MoonShotController>();
        foreach (MoonShotController moon in moonsArray)
        {
            if (areaOfInfluence.bounds.Contains(moon.transform.position))
            {
                Attract(moon);
                moonTimer += .02f;
                if (moonTimer > 1f && moonJuice.currentJuice < moonJuice.maximumJuice)
                {
                    moonJuice.currentJuice += .4f;
                }
                //Debug.Log(moonTimer);
                restartText.color = Color.clear;
            }
            
            if (moonTimer <= 0 && moonJuice.currentJuice <= 0)
            {
                StartCoroutine(FadeInRoutine());
            }
            
            if (deathZoneCollider.IsTouching(moon.gameObject.GetComponent<CircleCollider2D>()))
            {
                
                moon.MoonCollision(this.transform);
            }
            
        }

        Satellite[] satelliteArray = FindObjectsOfType<Satellite>();
        foreach (Satellite satellite in satelliteArray)
        {
            if (areaOfInfluence.bounds.Contains(satellite.transform.position))
            {
                Orbit(satellite);
                satellite.transform.Rotate(0, 0, 50 * Time.deltaTime);
            }

            if (deathZoneCollider.IsTouching(satellite.gameObject.GetComponent<CircleCollider2D>()))
            {

                satellite.SatCollision(this.transform);
            }
        }
    }

    void Attract(MoonShotController objToAttract)
    {
       
        Rigidbody2D moonToAttract = objToAttract.moonRB;

        Vector3 distanceVector = transform.position - moonToAttract.transform.position;
        distanceFromPlanet = distanceVector.magnitude;

        amountOfGravity = (massOfPlanet * moonToAttract.mass) / (Mathf.Pow(distanceFromPlanet, 2));
        Vector3 force = (distanceVector.normalized * amountOfGravity);

        moonToAttract.AddForce(force * 2, ForceMode2D.Impulse);

        AudioManager._Main.SetOrbitMeterRate(distanceFromPlanet);
        AudioManager._Main.SetWhiteNoiseVol(distanceFromPlanet, massOfPlanet);
    }

    void Orbit(Satellite objToAttract)
    {

        Rigidbody2D satToAttract = objToAttract.rb;

        Vector3 distanceVector = transform.position - satToAttract.transform.position;
        distanceFromPlanet = distanceVector.magnitude;

        amountOfGravity = (massOfPlanet * satToAttract.mass) / (Mathf.Pow(distanceFromPlanet, 2));
        Vector3 force = (distanceVector.normalized * amountOfGravity);

        satToAttract.AddForce(force * 2, ForceMode2D.Impulse);

    }

    private IEnumerator FadeInRoutine()
   {

       for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
       {
           restartText.color = Color.Lerp(Color.clear, originalColor, Mathf.Min(1, t * fadeOutTime));
           //Debug.Log("nice");
           yield return null;

       }



   }
    
}
