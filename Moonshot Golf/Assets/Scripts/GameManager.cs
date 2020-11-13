using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    
    public float restartDelay = 1f;
    public bool gameHasRestarted = false;
    public void EndGame()
    {

        if (gameHasRestarted == false)
        {
            gameHasRestarted = true;
            Debug.Log("Game");
            Invoke("Restart", restartDelay);
        }

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
