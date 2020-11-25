using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleMoonCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoonShotController[] moonsArray = FindObjectsOfType<MoonShotController>();

        if (moonsArray.Length >= 2)
        {
            Vector3 firstMoon = moonsArray[0].transform.position;
            Vector3 secondMoon = moonsArray[1].transform.position;
            Vector3 middlePoint = Vector3.Lerp(firstMoon, secondMoon, 0.5f);
            transform.position = middlePoint;
            //Debug.Log(moonsArray[0].transform.position);
        }



    }
}
