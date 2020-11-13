using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryJuice : MonoBehaviour
{

    public float maximumJuice;
    public float currentJuice;
    public Image mask;
    public Transform target;

    public VictoryTheScript victoryTheScript;
    // Start is called before the first frame update
    void Start()
    {
        victoryTheScript = FindObjectOfType<VictoryTheScript>();
        maximumJuice = victoryTheScript.timeToWin;
        target = victoryTheScript.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        mask.transform.position = target.position;
        currentJuice = victoryTheScript.moonTimer;
        //Debug.Log(currentJuice);
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = currentJuice / maximumJuice;
        mask.fillAmount = fillAmount;
    }
}
