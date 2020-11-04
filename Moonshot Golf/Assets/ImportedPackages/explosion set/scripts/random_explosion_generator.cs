using UnityEngine;
using System.Collections;

public class random_explosion_generator : MonoBehaviour {
    public GameObject explosion;

    // Update is called once per frame
    void OnMouseDown () {
        Vector3 pos = transform.position;
        pos.y+= 4;
            Instantiate(explosion, pos, transform.rotation);
        }
}
