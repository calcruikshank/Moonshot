using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGravity : MonoBehaviour
{
    public CircleCollider2D areaOfInfluence;
    public CircleCollider2D deathZoneCollider;
    public float amountOfGravity;
    public float massOfPlanet;
    public float distanceFromPlanet;
    

    //if you expect this to be an accurate calculation of mass and gravity then you would be very wrong

    

    void Update()
    {
        
    }
    void FixedUpdate()
    {
        MenuMoonShot[] moonsArray = FindObjectsOfType<MenuMoonShot>();
        foreach (MenuMoonShot moon in moonsArray)
        {
            if (areaOfInfluence.bounds.Contains(moon.transform.position))
            {
                Attract(moon);
                
                //Debug.Log(moonTimer);

            }
            if (deathZoneCollider.IsTouching(moon.gameObject.GetComponent<CircleCollider2D>()))
            {

                moon.MoonCollision(this.transform);
            }

        }

    }

    void Attract(MenuMoonShot objToAttract)
    {

        Rigidbody2D moonToAttract = objToAttract.moonRB;

        Vector3 distanceVector = transform.position - moonToAttract.transform.position;
        distanceFromPlanet = distanceVector.magnitude;

        amountOfGravity = (massOfPlanet * moonToAttract.mass) / (Mathf.Pow(distanceFromPlanet, 2));
        Vector3 force = (distanceVector.normalized * amountOfGravity);

        moonToAttract.AddForce(force * 2, ForceMode2D.Impulse);

    }

}
