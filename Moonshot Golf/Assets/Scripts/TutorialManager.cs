using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Text text;
    public Text text2;

    public float fadeOutTime = 1f;
    public bool pressedLeftClick = false;
    public Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        originalColor = text.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && pressedLeftClick == false)
        {
            StartCoroutine(FadeOutRoutine());
            StartCoroutine(FadeInRoutine());
            pressedLeftClick = true;
        }
    }

    private IEnumerator FadeOutRoutine()
    {
        
        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            text.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / fadeOutTime));
            
            yield return null;
            
        }

        

    }

    private IEnumerator FadeInRoutine()
    {
        
        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            text2.color = Color.Lerp(Color.clear, originalColor, Mathf.Min(1, t * fadeOutTime));
            Debug.Log("nice");
            yield return null;

        }



    }

}
