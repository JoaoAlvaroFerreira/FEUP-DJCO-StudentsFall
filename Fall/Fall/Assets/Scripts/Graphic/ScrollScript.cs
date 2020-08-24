using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public float speed = 0;
    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0f, Time.time * speed * Values.object_velocity_multiplier);   
    }
}
