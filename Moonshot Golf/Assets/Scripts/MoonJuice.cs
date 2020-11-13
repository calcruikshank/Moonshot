using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode()]
public class MoonJuice : MonoBehaviour
{

    public float maximumJuice;
    public float currentJuice;
    public Image mask;
    // Start is called before the first frame update
    void Start()
    {
        currentJuice = maximumJuice;
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = currentJuice / maximumJuice;
        mask.fillAmount = fillAmount;
    }
}
