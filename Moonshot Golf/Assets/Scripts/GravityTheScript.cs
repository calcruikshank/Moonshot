using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTheScript : MonoBehaviour
{
    public Rigidbody2D moonRB;
    public Transform thisTransform;
    public Transform moonTransform;

    public float amountOfGravity;
    public float massOfPlanet;
    public float distanceFromPlanet;
    public CircleCollider2D areaOfInfluence;
    public CircleCollider2D deathZoneCollider;
    public MoonShotController moonShotController;
    //if you expect this to be an accurate calculation of mass and gravity then you would be very wrong

    // Start is called before the first frame update
    void Start()
    {
        moonShotController = moonTransform.gameObject.GetComponent<MoonShotController>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (areaOfInfluence.bounds.Contains(moonTransform.position))
        {
            Debug.Log("Moon is affected");
            Vector3 distanceVector = transform.position - moonTransform.position;
            distanceFromPlanet = distanceVector.magnitude;

            //amountOfGravity = massOfPlanet * 100f;
            amountOfGravity = (massOfPlanet * moonRB.mass) / (Mathf.Pow(distanceFromPlanet, 2));
            Vector3 force = distanceVector.normalized * amountOfGravity;

            moonRB.AddForce(force * Time.deltaTime * 100, ForceMode2D.Impulse);
            //Debug.Log(force);
        }

        if (deathZoneCollider.bounds.Contains(moonTransform.position))
        {
            moonShotController.MoonCollision();
        }


    }

    
}
