using UnityEngine;
using System.Collections;

public class forcefield_destroy : MonoBehaviour {
    public GameObject ff;
    // Use this for initialization
    void OnDestroy()
    {
        Destroy(Instantiate(ff, transform.position, transform.rotation), 2f);
    }

    void Start()
    {
        Destroy(gameObject, 0.8f);
    }
}
