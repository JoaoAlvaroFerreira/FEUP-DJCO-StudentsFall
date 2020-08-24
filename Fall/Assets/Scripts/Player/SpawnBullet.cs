using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{

    public GameObject book_bullet = null;
    public GameObject character;


    // Start is called before the first frame update
    void Start()
    {

    }

    private float timer = 0f;
    public float bullet_spawn_time;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > bullet_spawn_time)
        {
             timer = 0;
            if(!character.GetComponent<DamageCheck>().controller){
               
            GameObject obj = (GameObject)Instantiate(book_bullet, new Vector2(character.transform.position.x, character.transform.position.y - 0.5f), Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(character.GetComponent<Rigidbody2D>().velocity.x, -10);
            }
            else{
            GameObject obj1 = (GameObject)Instantiate(book_bullet, new Vector2(character.transform.position.x-0.6f, character.transform.position.y - 0.5f), Quaternion.identity);
            obj1.GetComponent<Rigidbody2D>().velocity = new Vector2(character.GetComponent<Rigidbody2D>().velocity.x, -10);
            GameObject obj2 = (GameObject)Instantiate(book_bullet, new Vector2(character.transform.position.x, character.transform.position.y - 0.5f), Quaternion.identity);
            obj2.GetComponent<Rigidbody2D>().velocity = new Vector2(character.GetComponent<Rigidbody2D>().velocity.x, -10);
            GameObject obj3 = (GameObject)Instantiate(book_bullet, new Vector2(character.transform.position.x+0.6f, character.transform.position.y - 0.5f), Quaternion.identity);
            obj3.GetComponent<Rigidbody2D>().velocity = new Vector2(character.GetComponent<Rigidbody2D>().velocity.x, -10);
            }
            
        }
    }
}
