using UnityEngine;
using System.Collections;

public class black_hole_destroy : MonoBehaviour {
    public GameObject bh;
    // Use this for initialization
    void OnDestroy()
    {
        Destroy(Instantiate(bh, transform.position, transform.rotation), 2f);
    }

    void Start()
    {
        Destroy(gameObject, 1.25f);
    }
}
