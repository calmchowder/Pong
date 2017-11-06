using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {

    public float speed;
    public float boostSpeed;
    public string axisName;
    public bool playerOne;

    Rigidbody2D rb2d;

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        float v = Input.GetAxisRaw(axisName);

        // Boost speed
        if (Input.GetKey(KeyCode.LeftShift) && playerOne) {
            rb2d.velocity = new Vector2(0, v * boostSpeed);
        } else if (Input.GetKey(KeyCode.RightShift) && !playerOne) {
            rb2d.velocity = new Vector2(0, v * boostSpeed);

        // Normal Speed
        } else {
            rb2d.velocity = new Vector2(0, v * speed);
        }
    }

}
