using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = rb.velocity;

        velocity.x = 0;
        velocity.z = 0;

        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            velocity.x = -5f;
        }

        else if (Input.GetKey("d") || Input.GetKey("right"))
        {
            velocity.x = 5f; 
        }
        else if (Input.GetKey("w") || Input.GetKey("up"))
        {
            velocity.z = 5f;
        }
        else if (Input.GetKey("s") || Input.GetKey("down"))
        {
            velocity.z = -5f;
        }
        rb.velocity = velocity;
    }
}
