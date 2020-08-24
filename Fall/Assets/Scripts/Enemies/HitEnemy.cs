using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour
{

    private bool boss ;
    public GameObject beer;
    public GameObject pizza;
    public GameObject controller;

    public GameObject explosion;
    private bool explosionBool;
    GameObject explosionObj;
    private float explosionTimer = 0f;
    private float explosionTotalTimer = 1f;

    private void Start(){
        explosionBool = false;
    }

    private void Update() {
          if(explosionBool){
           
            explosionTimer += Time.deltaTime;
            if (explosionTimer >= explosionTotalTimer)
            {
               
                
                Destroy(explosionObj);
                explosionBool = false;
                explosionTimer = 0;
            }
        
    }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
            if(collision.gameObject.GetComponent<Enemy>().takeHit(Values.player_damage))
            {
                GameObject.Find("Game").GetComponent<TrackPoints>().killEnemy();
                SpawnPowerup(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y);
                if(collision.gameObject.GetComponent<Enemy>().boss>0){
                     explosionBool = true;
                     explosionObj = Instantiate(explosion, new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y), Quaternion.identity);

                }
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }

    void SpawnPowerup(float x, float y)
    {

        int a = Random.Range(0, 14);
        if (a == 0)
        {
            GameObject obj = (GameObject)Instantiate(beer, new Vector2(x, y), Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Values.powerup_velocity);
        }
        else if (a == 1)
        {
            GameObject obj = (GameObject)Instantiate(pizza, new Vector2(x, y), Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Values.powerup_velocity);
        }
        else if (a == 2)
        {
            GameObject obj = (GameObject)Instantiate(controller, new Vector2(x, y), Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Values.powerup_velocity);
        }
    }
}
