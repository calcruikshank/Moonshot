using UnityEngine;
using System.Collections;

public class explosion_destroy : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 1.2f);
    }
}
