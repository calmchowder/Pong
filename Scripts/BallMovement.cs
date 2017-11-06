using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    public float initialSpeed;
    public AudioSource hitSound;
    public AudioSource scoreSound;

    float ballSpeed;
    Rigidbody2D rb2d;
    ScoreManager scoreManager;

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        scoreManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreManager>();
        startGame();
    }

    // When the ball hits a paddle
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("LPaddle")) {
            hitSound.Play();
            float direction = ballAngleHit(transform, collision.transform, collision.collider.bounds.size.y);
            Vector2 newAngle = new Vector2(1, direction).normalized;
            rb2d.velocity = newAngle * ballSpeed;
            ballSpeed += 0.3f;
        }

        if (collision.gameObject.CompareTag("RPaddle")) {
            hitSound.Play();
            float direction = ballAngleHit(transform, collision.transform, collision.collider.bounds.size.y);
            Vector2 newAngle = new Vector2(-1, direction).normalized;
            rb2d.velocity = newAngle * ballSpeed;
            ballSpeed += 0.3f;
        }

        if (collision.gameObject.CompareTag("LSide")) {
            scoreSound.Play();
            scoreManager.rightScore += 1;
            startGame();
        }

        if (collision.gameObject.CompareTag("RSide")) {
            scoreSound.Play();
            scoreManager.leftScore += 1;
            startGame();
        }
    }

    // Calculates an angle for the ball to travel
    private float ballAngleHit (Transform ball, Transform racket, float paddleHeight) {
        return (ball.position.y - racket.position.y) / paddleHeight;
    }

    // Resets the ball for a new game
    private void startGame() {
        // For resetting purposes
        scoreManager.updateText();
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;

        // Ball speed is put 0.5f higher than intial due to the normalization of the vector below 
        ballSpeed = initialSpeed + 0.5f;

        // Give the ball an initial velocity in a random direction (4 different choices)
        float[] directions = new float[2] { -1, 1 };
        rb2d.velocity = new Vector2(directions[Random.Range(0, 2)] * initialSpeed, directions[Random.Range(0, 2)] * initialSpeed);
    }

}
