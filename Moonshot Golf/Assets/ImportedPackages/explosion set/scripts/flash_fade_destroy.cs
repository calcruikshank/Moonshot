using UnityEngine;
using System.Collections;

public class flash_fade_destroy : MonoBehaviour {
    public GameObject flash;
	// Use this for initialization
	void OnDestroy () {
        Destroy(Instantiate(flash, transform.position, transform.rotation), 0.2f);
    }
}
