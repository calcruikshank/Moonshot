using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSoundToLevelButtons : MonoBehaviour
{
    void Start()
    {
        foreach (Button button in GetComponentsInChildren<Button>())
        {
            button.onClick.AddListener(PlayStart);
            button.gameObject.AddComponent<MouseOverSound>();
        }
    }

    private void PlayStart()
    {
        AudioManager._Main.PlayStart();
    }
}
