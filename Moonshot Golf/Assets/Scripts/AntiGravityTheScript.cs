using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravityTheScript : MonoBehaviour
{

    public CircleCollider2D areaOfInfluence;
    public float distanceFromPlanet;
    public float amountOfGravity;
    public float massOfPlanet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        MoonShotController[] moonsArray = FindObjectsOfType<MoonShotController>();
        foreach (MoonShotController moon in moonsArray)
        {
            if (areaOfInfluence.bounds.Contains(moon.transform.position))
            {
                Repel(moon);
                

            }
            

        }

    }

    void Repel(MoonShotController objToAttract)
    {

        Rigidbody2D moonToAttract = objToAttract.moonRB;

        Vector3 distanceVector = transform.position - moonToAttract.transform.position;
        distanceFromPlanet = distanceVector.magnitude;

        amountOfGravity = (massOfPlanet * moonToAttract.mass) / (Mathf.Pow(distanceFromPlanet, 2));
        Vector3 force = (distanceVector.normalized * amountOfGravity);

        moonToAttract.AddForce(-force * 2, ForceMode2D.Impulse);

    }
}
