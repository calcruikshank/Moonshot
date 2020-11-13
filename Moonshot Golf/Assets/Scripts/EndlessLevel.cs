using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessLevel : MonoBehaviour
{
    private const float PLAYERDISTANCESPAWN = 200f;

    [SerializeField] private Transform planet1;
    [SerializeField] private Transform planet2;
    private MoonShotController moonShotController;
    private Vector3 lastEndPosition;


    void Awake()
    {
        moonShotController = FindObjectOfType<MoonShotController>();
        lastEndPosition = planet1.position;
        
        int numberOfPlanets = 5;
        for (int i = 0; i < numberOfPlanets; i++)
        {
            SpawnPlanet();
        }
        
    }

    void Update()
    {
        if (Vector3.Distance(moonShotController.gameObject.transform.position, lastEndPosition) < PLAYERDISTANCESPAWN)
        {
            SpawnPlanet();
        }
    }

    private void SpawnPlanet()
    {
        Transform lastLevelPartTransform = SpawnPlanet(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPoint").position;
    }

    private Transform SpawnPlanet(Vector3 spawnPosition)
    {
        Transform lastLevelPartTransform = Instantiate(planet1, spawnPosition, Quaternion.identity);
        return lastLevelPartTransform;

    }
}
