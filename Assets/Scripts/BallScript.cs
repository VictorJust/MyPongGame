using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float ballSpeed = 50f;
    [SerializeField] private Rigidbody ballRb;
    [SerializeField] private float maxSpeed = 100f;
    [SerializeField] private float speedIncreaseFactor = 1.1f;
    [SerializeField] private AudioClip hitPaddleSound;
    [SerializeField] private AudioClip hitWallSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ballRb = GetComponent<Rigidbody>();

        Launch();
    }

    private void Update()
    {
        LimitVelocity();
    }

    private void LimitVelocity()
    {
        if (ballRb.velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            ballRb.velocity = ballRb.velocity.normalized * maxSpeed;
        }
    }

    public void Launch(Vector3 launchVelocity)
    {
        ballRb.velocity = launchVelocity;
    }

    public void Launch()
    {
        float sx = Random.Range(-1f, 1f);
        float sz = Random.Range(-1f, 1f);

        Vector3 launchDirection = new Vector3(sx, 0, sz);
        Vector3 launchVelocity = launchDirection.normalized * ballSpeed;

        Launch(launchVelocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("Wall"))
        {
            Vector3 normal = collision.GetContact(0).normal;
            ballRb.velocity = Vector3.Reflect(ballRb.velocity, normal);

            IncreaseSpeed();
        }
    }

    private void IncreaseSpeed()
    {
        ballRb.velocity *= speedIncreaseFactor;
    }
}
