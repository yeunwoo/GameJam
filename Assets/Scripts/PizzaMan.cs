using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaMan : MonoBehaviour {

    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float jumpSpeedMultiplier = 3f;
    [SerializeField] private float fallMultiplier = 2.5f;

    [SerializeField] private float zMin = -4f;
    [SerializeField] private float zMax = -4f;


    [SerializeField] private float xMin = -3f;
    [SerializeField] private float xMax = 13f;

    [SerializeField] private AudioClip jumpSFX;

    private bool isJump = false;

    private Rigidbody rigidbody;
    private float jumpSpeed = 0f;

    private float zSpeed = 0f;
    private float xSpeed = 0f;

    private AudioSource asource;


    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        asource = GetComponent<AudioSource>();
    }

    private void Start() {
        zSpeed = speed;
        xSpeed = speed;

        // while (true) {
        //     yield return new WaitForSeconds(Random.Range(1, 5));
        //     float jumpSpeed = Random.Range(2, 6);
        //     Jump(jumpSpeed);
        // }

    }

    private void Update() {
        if (Input.GetButtonDown("Jump")) {
            Jump(3f);
        }
    }


    private void FixedUpdate() {


        float verticalSpeed = rigidbody.velocity.y;

        if (isJump) {
            verticalSpeed = jumpSpeed;
            isJump = false;
        }

        if (rigidbody.velocity.y < 0) {
            verticalSpeed += Physics.gravity.y * fallMultiplier * Time.fixedDeltaTime;
        }

        float z_pos = transform.position.z;
        if (z_pos >= zMax) {
            zSpeed = -speed;
        } else if (z_pos <= zMin) {
            zSpeed = speed;
        }

        float x_pos = transform.position.x;
        if (x_pos >= xMax) {
            xSpeed = -speed;
        } else if (x_pos <= xMin) {
            xSpeed = speed;
        }

        // rigidbody.velocity = new Vector3(0, verticalSpeed, horizontalSpeed);
        rigidbody.velocity = new Vector3(xSpeed, verticalSpeed, zSpeed);


    }

    public void Jump(float speed) {
        jumpSpeed = speed * jumpSpeedMultiplier;
        isJump = true;
        asource.PlayOneShot(jumpSFX, 0.5f);
    }
}
