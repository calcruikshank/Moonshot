using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    void Update()
    {
        if (PlayerPrefs.GetInt("level") <= 0)
        {
            PlayerPrefs.SetInt("level", 1);
        }
    }
    public void PlayGame()
    {

        SceneManager.LoadScene(PlayerPrefs.GetInt("level"));


        AudioManager._Main.StartGameDelay();
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }


    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteKey("level");
    }
}
