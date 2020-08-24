using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    // Start is called before the first frame update
     public GameObject table_obstacle;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    private float timer = 0f;

    void Update()
    {
        
         timer += Time.deltaTime;
        if(timer > Values.table_spawn_time)
        {

            timer = 0;
            Vector2 velocity = new Vector2(0, Values.object_velocity);
            GameObject obj =Instantiate<GameObject>(table_obstacle, new Vector2(Random.Range(-4.0f,4.0f),-6), Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().velocity = velocity;
            obj.GetComponent<UpdateObstacleVelocity>().setVelocity(velocity);

        }
    }
}
