using UnityEngine;
using System.Collections;

public class time_distort_destroy : MonoBehaviour {
    public GameObject td;
	// Use this for initialization
	void OnDestroy () {
        Destroy(Instantiate(td, transform.position, transform.rotation), 2f);
	}

    void Start()
    {
        Destroy(gameObject, 0.2f);
    }
}
