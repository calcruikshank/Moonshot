using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTheSecondScript : MonoBehaviour
{
    
    public CircleCollider2D areaOfInfluence;
    public CircleCollider2D deathZoneCollider;
    public float amountOfGravity;
    public float massOfPlanet;
    public float distanceFromPlanet;
    public MoonJuice moonJuice;
    public float moonTimer;

    //if you expect this to be an accurate calculation of mass and gravity then you would be very wrong

    void Start()
    {
        moonJuice = FindObjectOfType<MoonJuice>();
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

}
