using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{

    public float startingVelocity = 0f;
    
    public Rigidbody2D rb;
    public CircleCollider2D deathZoneCollider;

    public GameObject explosionPrefab;
    public GameObject newExplosion;
    public bool satCollided = false;

    void Awake()
    {
        rb.AddForce(-transform.up * startingVelocity * 3.3f, ForceMode2D.Impulse);
        transform.Rotate(0, 0, Random.Range(0, 360));
    }
    void Start()
    {
        satCollided = false;
    }
    // Update is called once per frame
    void Update()
    {
        
        MoonShotController[] moonsArray = FindObjectsOfType<MoonShotController>();
        foreach (MoonShotController moon in moonsArray)
        {
            
            /*if (deathZoneCollider.IsTouching(moon.gameObject.GetComponent<CircleCollider2D>()))
            {

                moon.MoonCollision(this.transform);
            }*/

        }
    }

    public void SatCollision(Transform otherCollision)
    {
        if (satCollided == false)
        {
            newExplosion = Instantiate(explosionPrefab, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
            newExplosion.transform.up = newExplosion.transform.position - otherCollision.position;
            gameObject.SetActive(false);
            satCollided = true;
        }
    }
}
