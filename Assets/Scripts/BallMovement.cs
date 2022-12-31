using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float ballVelocity = 500f;

    public Rigidbody rigidbody;
    public float zRange = 20;
    public float maxVelocity = 100f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sz = Random.Range(0, 2) == 0 ? -1 : 1;

        rigidbody.AddForce(ballVelocity * sx, ballVelocity * sz, 0, ForceMode.Force);
    }
    void FixedUpdate()
    {
        if (rigidbody.velocity.sqrMagnitude > maxVelocity)
        {
            //smoothness of the slowdown is controlled by the 0.99f, 
            //0.5f is less smooth, 0.9999f is more smooth
            rigidbody.velocity *= 0.99f;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        rigidbody.AddForce(collision.contacts[0].normal * ballVelocity, ForceMode.Force);
    }
}
