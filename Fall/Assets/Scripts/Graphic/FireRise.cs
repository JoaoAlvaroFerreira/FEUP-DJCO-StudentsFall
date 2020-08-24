using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRise : MonoBehaviour
{
    // Start is called before the first frame update
    int diff;
    GameObject player;
    public GameObject fire;
    List<GameObject> fires;
    DamageCheck playerScript;
    GameObject ring;
    void Start()
    {
        fires = new List<GameObject>();
        player = GameObject.Find("Character");
        playerScript = player.GetComponent<DamageCheck>();
        ring = GameObject.Find("RingOfFire");
        diff = playerScript.diff;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        
        if(playerScript.diff > diff){
            diff = playerScript.diff;
           upFireHeight();
        }
        else if(playerScript.diff < diff){
           diff = playerScript.diff;
           minFireHeight();
          
        }

       
    }

    private void upFireHeight(){
     
   
     fires.Add((GameObject)Instantiate(fire, new Vector2(ring.transform.position.x, ring.transform.position.y+diff*1.8f), Quaternion.identity));
        
     
     
    }

    private void minFireHeight(){
        GameObject fireToRemove = fires[fires.Count - 1];
        fires.Remove(fireToRemove);
        Destroy(fireToRemove);
    }
}
