using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTheScript : MonoBehaviour
{
    
    public CircleCollider2D areaOfInfluence;
    public int orbitingMoons = 0;
    public int numOfMoonToWin = 0;
    public int numOfMoonsInScene = 0;
    public float timeToWin = 5f;
    public float moonTimer;
    ///public GameManager gameManager;

    void Update()
    {

        MoonShotController[] moonsArray = FindObjectsOfType<MoonShotController>();
        numOfMoonsInScene = moonsArray.Length;

        if (numOfMoonsInScene < numOfMoonToWin)
        {
            Defeat();
        }

       // Debug.Log(numOfMoonsInScene);
        foreach (MoonShotController moon in moonsArray)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                moonTimer = 0f;
                AudioManager._Main.RestartOrbitMeter();
            }
            if (areaOfInfluence.bounds.Contains(moon.transform.position))
            {
                if (moon.addedMoonToVictoryInt == false)
                {
                    orbitingMoons++;
                    moon.addedMoonToVictoryInt = true;
                    
                }

            }
            if (!areaOfInfluence.bounds.Contains(moon.transform.position))
            {
                if (moon.addedMoonToVictoryInt == true)
                {
                    orbitingMoons--;
                    moon.addedMoonToVictoryInt = false;
                }

            }

        }

        if (orbitingMoons >= numOfMoonToWin)
        {
            moonTimer += Time.deltaTime;
        }

        if (moonTimer >= timeToWin)
        {
            Victory();
        }
    }

    public void Victory()
    {
        Debug.Log("Victory");
        //gameManager.CompleteLevel();
        AudioManager._Main.PlayWin();
        FindObjectOfType<GameManager>().CompleteLevel();
    }

    public void Defeat()
    {
        //Debug.Log("Defeat");
        FindObjectOfType<GameManager>().EndGame();
    }

}
