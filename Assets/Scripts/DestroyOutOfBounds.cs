using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float sideBound = 40;

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x > sideBound) || (transform.position.x < -sideBound))
        {
            Destroy(gameObject);
        }
    }
}
