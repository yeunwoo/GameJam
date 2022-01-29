using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatKeeper : MonoBehaviour
{
    Material mat;
    [SerializeField]
    Color color = Color.yellow;

    void Start() {
        this.mat = GetComponent<Renderer>().material;
        this.color.a = 0;
        mat.color = this.color;
    }

    void Update() {
        if (this.color.a > 0) {
            this.color.a -= 3.0f * Time.deltaTime;
            mat.color = this.color;
        }
    }

    public void Beat() {
        this.color.a = 1;
    }
}
