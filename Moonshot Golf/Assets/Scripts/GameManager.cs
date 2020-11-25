using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    
    public float restartDelay = 1f;
    public bool gameHasRestarted = false;
    public int level = 1;
    public void EndGame()
    {

        if (gameHasRestarted == false)
        {
            gameHasRestarted = true;
            Debug.Log("Game");
            Invoke("Restart", restartDelay);
            AudioManager._Main.StopOrbitMeter();
			AudioManager._Main.PlayLose();
            AudioManager._Main.StopWhiteNoise();
        }

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Restart();
            //ResetPlayerPrefs();
        }
    }

    void Restart()
    {
        AudioManager._Main.PlayWhiteNoise1();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        AudioManager._Main.PlayWhiteNoise1();
        level = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SaveLevel();
    }

    public void SaveLevel()
    {
        if (level > PlayerPrefs.GetInt("level"))
        {
            PlayerPrefs.SetInt("level", level);
            Debug.Log(PlayerPrefs.GetInt("level"));
        }
        
    }

}
