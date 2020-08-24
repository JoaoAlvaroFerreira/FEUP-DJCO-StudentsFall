using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_book : MonoBehaviour
{

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddTorque(Random.Range(-1.0f, 1.0f) * 1000);
    }
}
