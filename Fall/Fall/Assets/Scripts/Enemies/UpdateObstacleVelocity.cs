using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateObstacleVelocity : MonoBehaviour
{
    private Vector2 original = new Vector2(0, 0);
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(original.x * Values.object_velocity_multiplier, original.y * Values.object_velocity_multiplier);
    }

    public void setVelocity(Vector2 v)
    {
        this.original = v;
    }
}
