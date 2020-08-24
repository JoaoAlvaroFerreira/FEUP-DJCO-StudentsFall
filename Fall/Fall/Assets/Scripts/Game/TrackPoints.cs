using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrackPoints : MonoBehaviour
{
    // Start is called before the first frame update
    private float totalPoints;
    private float enemyKillPoints;
    void Start()
    {
        totalPoints = 0;
        enemyKillPoints = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float truncated = (float)(Math.Truncate((double)Time.time));
        totalPoints = truncated*10 + enemyKillPoints;
        
    }

    public void killEnemy(){
        enemyKillPoints += 100;
    }
    

    public float getPoints(){
        return totalPoints;
      
    }
}
