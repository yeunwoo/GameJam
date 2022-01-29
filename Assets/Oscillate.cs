using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillate : MonoBehaviour {

    [SerializeField] private float zMin = -8f;
    [SerializeField] private float zMax = -1f;

    private float speed = 0;

    // Start is called before the first frame update
    void Start() {
        speed = 5f;
    }

    // Update is called once per frame
    void Update() {

        if (transform.position.z >= zMax) {
            speed = -5f;
            print("WTF");
        } else if (transform.position.z <= zMin) {
            speed = 5f;
            print("WTF2");

        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
