using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryJuice : MonoBehaviour
{

    public float maximumJuice;
    public float currentJuice;
    public Image mask;

    public VictoryTheScript victoryTheScript;
    // Start is called before the first frame update
    void Start()
    {
        victoryTheScript = FindObjectOfType<VictoryTheScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
