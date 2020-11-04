using UnityEngine;
using System.Collections;

public class forcefield_bump_destroy : MonoBehaviour {
    public GameObject fb;
    // Use this for initialization
    void OnDestroy()
    {
        Destroy(Instantiate(fb, transform.position, transform.rotation), 0.4f);
    }
}
