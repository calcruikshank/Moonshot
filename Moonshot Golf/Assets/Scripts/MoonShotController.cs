using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonShotController : MonoBehaviour
{

    public Rigidbody2D moonRB;
    
    public float appliedForce = 0f;
    public bool ableToShoot = true;
    public float chargeTimer = 0f;
    public Vector2 direction;
    public float startingVelocity;
    public GameObject blackHolePrefab;
    public GameObject newBlackHole;

    public GameObject explosionPrefab;

    public float topSpeed = 80f;

    // Start is called before the first frame update
    void Start()
    {
        moonRB.AddForce(-transform.up * startingVelocity * Time.deltaTime * 165, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(moonRB.velocity.magnitude);
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePosition = GetMousePosition();
            newBlackHole = Instantiate(blackHolePrefab, new Vector3(mousePosition.x, mousePosition.y, 0f), Quaternion.identity);
        }
        if (Input.GetButton("Fire1"))
        {
            //SetBlackHoleTransform();
            //ChargeMoonShot();
            GetDirection();

            MoonShot();

        }

        if (Input.GetButtonUp("Fire1"))
        {
            //GetDirection();
            //MoonShot();
            Destroy(newBlackHole);

        }
       

    }
    public void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && newBlackHole != null)
        {
            SetBlackHoleTransform();
            

        }
    }

    public void ChargeMoonShot()
    {
        
        chargeTimer += Time.deltaTime;
        appliedForce += Time.deltaTime * 60;
        if (appliedForce > 70)
        {
            appliedForce = 70;
        }
        //Debug.Log(appliedForce);
    }

    public void MoonShot()
    {
        appliedForce = .5f;
        moonRB.AddForce(direction * appliedForce * Time.deltaTime * 165, ForceMode2D.Impulse);
        if (moonRB.velocity.magnitude > topSpeed)
        {
            moonRB.velocity = moonRB.velocity.normalized * topSpeed;
        }
        
    }

    public void GetDirection()
    {
        Vector3 mousePosition = GetMousePosition();

        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y).normalized;
        //transform.right = direction;
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        return mousePosition;
    }

    public void SetBlackHoleTransform()
    {
        Vector3 blackHolePosition = GetMousePosition();
        blackHolePosition = new Vector3(blackHolePosition.x, blackHolePosition.y, 0f);
        newBlackHole.transform.position = blackHolePosition;
    }

    public void MoonCollision()
    {
        if (newBlackHole != null)
        {
            Destroy(newBlackHole);
            gameObject.SetActive(false);
        }
        
    }

}
