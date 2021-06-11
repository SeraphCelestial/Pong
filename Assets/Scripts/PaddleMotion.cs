using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMotion : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0.0f, 5.0f);
        }
        else if( Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(0.0f, -5.0f);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if (transform.position.y <  -3.59f)
        {
            transform.position = new Vector3(-6.5f, -3.58f, 0);
        }

        if (transform.position.y > 3.59f)
        {
            transform.position = new Vector3(-6.5f, 3.58f, 0);
        }
    }
}
