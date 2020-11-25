using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public void UpdateVolume()
    {
        AudioManager._Main.SetMasterVol(GetComponent<Slider>().value);
    }
}
