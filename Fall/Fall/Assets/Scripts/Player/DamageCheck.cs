using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Alive,
    Drunk,
    Invincible,
    Dead,
}

public class DamageCheck : MonoBehaviour
{


    SpriteRenderer m_SpriteRenderer;

    public GameObject player;
    public GameObject fire;

    public GameObject explosion;

    GameObject explosionObj;
    public bool controller;

    private bool explosionBool;


    public State state;
    public int startingHealth = 5;                            // The amount of health the player starts the game with.
    public int currentHealth;            // The current health the player has.
    public int diff;                       //difference between current and starting health
                                           // Start is called before the first frame update

    private float invicibilityTimer;
    public float invicibilityTimeTotal = 5;

    private float drunkTimer = 0f;
    private float drunkTotalTime = 5f;
    private float controllerTimer = 0f;
    private float controllerTotalTimer = 10f;

    private float explosionTimer = 0f;
    private float explosionTotalTimer = 1f;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        changeState("Alive");
        currentHealth = startingHealth;
        controller = false;
        explosionBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(controller){
            controllerTimer += Time.deltaTime;
            if (controllerTimer >= controllerTotalTimer)
            {
                controllerTimer = 0;
                controller = false;
            }
        }
        if (state == State.Drunk)
        {
            drunkTimer += Time.deltaTime;
            if (drunkTimer >= drunkTotalTime)
            {
                drunkTimer = 0;
                changeState("Alive");
            }
        }
        if (state == State.Invincible)
        {

            invicibilityTimer += Time.deltaTime;
            if (invicibilityTimer > invicibilityTimeTotal)
            {
                invicibilityTimer = 0;
                changeState("Alive");
            }
        }
       if (player.transform.position.y < diff*1.6-2.8f)
        {

            changeState("Dead");
        }

        if(explosionBool){
           
            explosionTimer += Time.deltaTime;
            if (explosionTimer >= explosionTotalTimer)
            {
                Debug.Log("b");
                
                Destroy(explosionObj);
                explosionBool = false;
                explosionTimer = 0;
            }
        
    }
    }

    void DealDamage()
    {
        if (state != State.Invincible)
        {
            currentHealth--;

            explosionBool = true;
           explosionObj = Instantiate(explosion, new Vector2(player.transform.position.x, player.transform.position.y), Quaternion.identity);


            diff = startingHealth - currentHealth;

            changeState("Invincible");


            ClearScreen.clear();
        }

    }


    void RecoverHealth()
    {
        currentHealth++;
        if (currentHealth > startingHealth)
        {
            currentHealth = startingHealth;
        }
        diff = startingHealth - currentHealth;
    }

    void changeState(string s)
    {
        switch (s)
        {
            case "Alive":
                m_SpriteRenderer.color = Color.white;
                state = State.Alive;
                normalizeValues();
                break;
            case "Drunk":
                drunkTimer = 0;
                m_SpriteRenderer.color = Color.green;
                Values.object_velocity_multiplier = 0.5f;
                Values.bullet_velocity_multiplier = 0.5f;
                Values.enemy_velocity_multiplier = 0.5f;
                state = State.Drunk;
                break;
            case "Invincible":
                m_SpriteRenderer.color = Color.red;
                state = State.Invincible;
                normalizeValues();
                controller = false;
                break;
            case "Dead":
                state = State.Dead;
                m_SpriteRenderer.color = Color.blue;
                break;
        }
    }

    void normalizeValues()
    {
        drunkTimer = 0;
        Values.object_velocity_multiplier = 1f;
        Values.bullet_velocity_multiplier = 1f;
        Values.enemy_velocity_multiplier = 1f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {


        if (col.gameObject.tag == "Obstacle")
        {
            DealDamage();
        }
        else if (col.gameObject.tag == "Projectile")
        {
            DealDamage();
        }
        else if (col.gameObject.tag == "Enemy")
        {
            DealDamage();
        }
        else if (col.gameObject.tag == "Pizza")
        {

            RecoverHealth();
        }
        else if (col.gameObject.tag == "Controller")
        {
            controller = true;
            
        }
        else if (col.gameObject.tag == "Beer")
        {

            changeState("Drunk");
        }

        Destroy(col.gameObject);
    }

}
