using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAudio : MonoBehaviour
{
    public enum ButtonType { Select, Confirm, Start };

    [SerializeField]
    private ButtonType _CurrentButtonType;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(PlayButtonSound);
    }

    void PlayButtonSound()
    {
        switch (_CurrentButtonType)
        {
            case ButtonType.Select:
                AudioManager._Main.PlaySelect();
                break;
            case ButtonType.Confirm:
                AudioManager._Main.PlayConfirm();
                break;
            case ButtonType.Start:
                AudioManager._Main.PlayStart();
                break;
            default:
                Debug.Log("No audio to play; unknown button type");
                break;
        }
    }
}
