using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaMan : MonoBehaviour {

    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float jumpSpeedMultiplier = 3f;
    [SerializeField] private float fallMultiplier = 2.5f;

    [SerializeField] private float zMin = -8f;
    [SerializeField] private float zMax = -1f;

    private bool isJump = false;

    private Rigidbody rigidbody;
    private float jumpSpeed = 0f;

    private float horizontalSpeed = 0f;


    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private IEnumerator Start() {
        horizontalSpeed = speed;

        while (true) {
            yield return new WaitForSeconds(Random.Range(1, 5));
            float jumpSpeed = Random.Range(2, 6);
            Jump(jumpSpeed);
        }

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

        if (transform.position.z >= zMax) {
            horizontalSpeed = -speed;
        } else if (transform.position.z <= zMin) {
            horizontalSpeed = speed;
        }

        rigidbody.velocity = new Vector3(0, verticalSpeed, horizontalSpeed);



    }

    public void Jump(float speed) {
        jumpSpeed = speed * jumpSpeedMultiplier;
        isJump = true;
    }
}
