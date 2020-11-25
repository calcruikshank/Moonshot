using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onslaught : MonoBehaviour
{
    private const float PLAYERDISTANCESPAWN = 200f;
    public float respawnTime = .5f;
    private MoonShotController moonShotController;
    public Transform playerTransform;
    public GameObject asteroidPrefab;

    // Start is called before the first frame update
    void Start()
    {
        moonShotController = FindObjectOfType<MoonShotController>();

        StartCoroutine(AsteroidWave());
        
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = moonShotController.gameObject.transform;
    }

    private void SpawnObstacle()
    {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = new Vector2(playerTransform.position.x + 70, Random.Range(playerTransform.position.y, playerTransform.position.y + 100));
    }

    IEnumerator AsteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnObstacle();
        }
    }
}
