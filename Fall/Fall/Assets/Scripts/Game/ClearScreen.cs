using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScreen : MonoBehaviour
{

    public static void clear()
    {
        object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));

        foreach (object o in obj)
        {
            GameObject g = (GameObject)o;
            if (g.tag == "Obstacle" || g.tag == "Projectile")
            {

                Destroy(g);
            }
        }
    }
}
