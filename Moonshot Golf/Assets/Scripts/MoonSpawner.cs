using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonSpawner : MonoBehaviour
{
    public GameObject moonPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            MakeMoon();
        }
    }


    public void MakeMoon()
    {
        Vector3 newMoonPosition = GetMousePosition();
        GameObject newMoon = Instantiate(moonPrefab, new Vector3(newMoonPosition.x, newMoonPosition.y, 0f), Quaternion.identity);
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        return mousePosition;
    }
}
