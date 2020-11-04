using UnityEngine;
using System.Collections;

public class explosion_wave_movement : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.y += 0.06f;
        transform.position = pos;
	}
}
