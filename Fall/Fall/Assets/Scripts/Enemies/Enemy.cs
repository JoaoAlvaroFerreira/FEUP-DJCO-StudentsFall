using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Vector2 position1;
    private Vector2 position2;
    private int to_position = 0;
    private Vector2 starting_position;
    public GameObject bullet_type;
    private float time = 0f;
    private float t = 0f;
    private ArrayList wave;
    private int hp;
    private float fire_interval;
    public int boss;

    private void Start()
    {
        starting_position = transform.position;
    }
    private void Update()
    {
        t += Time.deltaTime * Values.enemy_velocity * Values.enemy_velocity_multiplier;
        time += Time.deltaTime;
        if (to_position == 1 || to_position == 0)
        {
            transform.position = Vector2.Lerp(starting_position, this.position1, t);
            if(((Vector2)transform.position) == this.position1)
            {
                to_position = 2;
                starting_position = transform.position;
                t = 0;
            }
        }
        else if (to_position == 2)
        {
            transform.position = Vector2.Lerp(starting_position, this.position2, t);
            if (((Vector2)transform.position) == this.position2)
            {
                to_position = 1;
                starting_position = transform.position;
                t = 0;
            }
        }
        if (time >= this.fire_interval && to_position != 0)
        {
            spawnBullet();
            time = 0;
        }
    }

    public void setToPosition1(Vector2 position)
    {
        this.position1 = position;
    }
    public void setToPosition2(Vector2 position)
    {
        this.position2 = position;
    }

    public void setTypeBullet(GameObject bullet_type)
    {
        this.bullet_type = bullet_type;
    }

    public void setWave(ArrayList lista)
    {
        this.wave = lista;
    }

    public void setHp(int hp)
    {
        this.hp = hp;
    }

    public bool takeHit(int value)
    {
        this.hp -= value;
        if (this.hp <= 0)
            return true;
        return false;
    }

    public void setFireInterval(float interval)
    {
        this.fire_interval = interval;
    }

    public void setIsBoss(int boss)
    {
        this.boss = boss;
    }

    public void spawnBullet()
    {
        for(int i = 0; i< wave.Count;i++)
        {
            Vector2 velocity = new Vector2(((float) wave[i]) * Values.bullet_velocity, 6 * Values.bullet_velocity);
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            GameObject go = Instantiate<GameObject>(bullet_type, transform.position, Quaternion.Euler(new Vector3(0, 0, angle - 90)));
            go.GetComponent<Rigidbody2D>().velocity = velocity;
            go.GetComponent<UpdateBulletVelocity>().setVelocity(velocity);
        }
    }
}
