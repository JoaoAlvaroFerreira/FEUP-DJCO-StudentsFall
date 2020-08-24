using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Apagar as balas e obstaculos quando saem do ecra
/// </summary>
public class DeleteEnemy : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject);
        }
    }
}
