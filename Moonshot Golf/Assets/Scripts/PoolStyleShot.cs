using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolStyleShot : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform firePoint;
    public float cueForce = 0f;
    public bool abletoShoot = true;
    public float chargeTimer = 0f;
    //attempt to create mouse drag option

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        faceMouse();



        if (Input.GetButton("Fire1"))
        {
            startCharge();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            launchCueBall();
        }

    }

    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.right = direction;
    }


    void startCharge()
    {
        //rb.velocity = rb.velocity * 0.99f;
        chargeTimer += Time.deltaTime;
        cueForce += chargeTimer;
        Debug.Log(cueForce);
        if (cueForce > 50)
        {
            cueForce = 50;
        }
    }


    void launchCueBall()
    {
        rb.AddForce(firePoint.right * cueForce, ForceMode2D.Impulse);
        //abletoShoot = false;
        chargeTimer = 0;
        cueForce = 5;
    }
}
