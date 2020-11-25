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
    public Image waypoint;
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
        Vector3 toPosition = target.position;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;


        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (angle < 0) angle += 360;

        waypoint.transform.localEulerAngles = new Vector3(0, 0, angle);


        float borderSize = 100f;
        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(target.position);
        
        bool isOffScreen = targetPositionScreenPoint.x <= borderSize || targetPositionScreenPoint.x >= Screen.width - borderSize || targetPositionScreenPoint.y <= borderSize || targetPositionScreenPoint.y >= Screen.height - borderSize;
        
        if (isOffScreen)
        {
            /*var tempColor = waypoint.color;
            tempColor.a = .5f;
            waypoint.color = tempColor;*/
            waypoint.GetComponent<CanvasGroup>().alpha = 1;

            //Debug.Log(isOffScreen);
            Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
            if (cappedTargetScreenPosition.x <= borderSize) cappedTargetScreenPosition.x = borderSize;
            
            if (cappedTargetScreenPosition.x >= Screen.width - borderSize) cappedTargetScreenPosition.x = Screen.width - borderSize;
            
            if (cappedTargetScreenPosition.y <= borderSize) cappedTargetScreenPosition.y = borderSize;
            
            if (cappedTargetScreenPosition.y >= Screen.height - borderSize) cappedTargetScreenPosition.y = Screen.height - borderSize;
            


            Vector3 pointerWorldPosition = Camera.main.ScreenToWorldPoint(cappedTargetScreenPosition);
            waypoint.transform.position = pointerWorldPosition;
            waypoint.transform.localPosition = new Vector3(waypoint.transform.localPosition.x, waypoint.transform.localPosition.y, 0f);
        }
        if (!isOffScreen)
        {
            var tempColor = waypoint.color;
            tempColor.a = 0f;
            waypoint.color = tempColor;
            waypoint.GetComponent<CanvasGroup>().alpha = 0;
        }

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
