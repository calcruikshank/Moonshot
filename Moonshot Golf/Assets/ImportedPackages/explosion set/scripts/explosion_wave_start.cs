using UnityEngine;
using System.Collections;

public class explosion_wave_start : MonoBehaviour {
    public GameObject exw;
    // Use this for initialization
    void OnMouseDown()
    {
        {
            Vector3 pos = new Vector3(0, -6, 0);
            Destroy(Instantiate(exw, pos, transform.rotation), 4f);
            pos = new Vector3(2.56f, -6, 0);
            Destroy(Instantiate(exw, pos, transform.rotation), 4f);
            pos = new Vector3(-2.56f, -6, 0);
            Destroy(Instantiate(exw, pos, transform.rotation), 4f);
            pos = new Vector3(-5.12f, -6, 0);
            Destroy(Instantiate(exw, pos, transform.rotation), 4f);
            pos = new Vector3(5.12f, -6, 0);
            Destroy(Instantiate(exw, pos, transform.rotation), 4f);
            pos = new Vector3(-7.68f, -6, 0);
            Destroy(Instantiate(exw, pos, transform.rotation), 4f);
            pos = new Vector3(7.68f, -6, 0);
            Destroy(Instantiate(exw, pos, transform.rotation), 4f);
        }
    }
}
