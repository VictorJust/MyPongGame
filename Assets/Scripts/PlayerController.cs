using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float zRange = 20;
    public float xRange = 40;

    public bool isPlayer1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move rackets by players
        if (isPlayer1)
        {
            transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed);
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") *Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector3.forward * Input.GetAxis("Vertical2") * Time.deltaTime * speed);
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal2") *Time.deltaTime * speed);
        }

        // Not letting rackets go beyond table edges
        // z axis position
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(-zRange, transform.position.y, transform.position.x);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(zRange, transform.position.y, transform.position.x);
        }
        // x axis position
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
