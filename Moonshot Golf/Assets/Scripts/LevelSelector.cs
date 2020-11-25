using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelSelector : MonoBehaviour
{


    public Transform levelsParent;
    CheckIfUnlocked[] levels;
    // Start is called before the first frame update
    void Start()
    {
        levels = levelsParent.GetComponentsInChildren<CheckIfUnlocked>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < levels.Length; i++) // the first level is always unlocked
        {
            if (PlayerPrefs.GetInt("level") > i)
            {
                levels[i].gameObject.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
                levels[i].gameObject.GetComponent<Button>().interactable = true;
                Debug.Log(i);
            }
            
        }
    }

    public void Select(int levelPressed)
    {
        SceneManager.LoadScene(levelPressed);
        AudioManager._Main.StartGameDelay();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
