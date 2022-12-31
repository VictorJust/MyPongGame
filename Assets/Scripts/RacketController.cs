using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    public Rigidbody rb;
    public float forceStrength = 20;
    public bool isPlayer1;
    public float zRange = 20;
    public float xRange = 40;

    float forceControl;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
            forceControl = Input.GetAxis("Vertical");
        }
        else
        {
            forceControl = Input.GetAxis("Vertical2");
        }


        // Not letting rackets go beyond table edges
        if (transform.position.z < -zRange || transform.position.z > zRange || transform.position.x < -xRange || transform.position.x > xRange)
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * forceControl * forceStrength);
    }
}
