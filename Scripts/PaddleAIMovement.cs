using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAIMovement : MonoBehaviour {

    public float speed;
    Rigidbody2D rb2d;
    Transform theBall;

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        theBall = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    private void FixedUpdate() {

        // Move downwards if the paddle is above the ball
        if (transform.position.y > theBall.position.y + 0.1) {
            rb2d.velocity = new Vector2(0, -1 * speed);

        // Move upwards if the paddle is below the ball
        } else if (transform.position.y < theBall.position.y - 0.1) {
            rb2d.velocity = new Vector2(0, 1 * speed);

        // Don't move if the paddle can hit the ball in its current position
        } else {
            rb2d.velocity = Vector2.zero;
        }

    }
}
