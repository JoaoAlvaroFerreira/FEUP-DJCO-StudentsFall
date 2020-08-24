using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class Controller : MonoBehaviour
{
    public bool gameWin;
    public TextAsset xmlRawFile;
    private ArrayList enemies;
    private ArrayList levels;
    private Boolean level_spawned = false;
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        gameWin = false;
        enemies = new ArrayList();
        levels = new ArrayList();
        try
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(new StringReader(xmlRawFile.text));
            XmlNode patterns = xmlDoc.DocumentElement;
            if (patterns.Name == "patterns")
            {
                if(patterns.ChildNodes[0].Name == "enemies")
                {
                    foreach (XmlNode enemy in patterns.ChildNodes[0].ChildNodes)
                    {
                        string enemy_name = enemy.Attributes["name"].Value;
                        ParseEnemy parseEnemy = new ParseEnemy(enemy_name, enemy);
                        enemies.Add(parseEnemy);
                    }
                }
                else
                {
                    throw new ParsingError("patterns should have enemies");
                }

                if (patterns.ChildNodes[1].Name == "levels")
                {
                    foreach (XmlNode level in patterns.ChildNodes[1].ChildNodes)
                    {
                        int level_number = int.Parse(level.Attributes["number"].Value);
                        ParseLevels parseLevels = new ParseLevels(level_number, level);
                        levels.Add(parseLevels);
                    }
                }
                else
                {
                    throw new ParsingError("patterns should have enemies");
                }
            }
            else
                throw new ParsingError("root name should be patterns");

        }
        catch(Exception e)
        {
            Debug.LogError(e);
        }
    }

    // Update is called once per frame

        

    void Update()
    {
        time += Time.deltaTime;
        if(!level_spawned && ((ParseLevels)levels[0]).PlayLevel(Time.deltaTime,this.enemies))
        {
            level_spawned = true;
        }


        if(level_spawned && this.time >= 1)
        {
            time = 0;
            GameObject[] obj = GameObject.FindGameObjectsWithTag("Enemy");
            if (obj.Length == 0)
                {
                    gameWin = true;
                }
        }  
    }

    public static GameObject ints(UnityEngine.Object type, Vector2 position, Quaternion rotation)
    {
        return Instantiate(type, position, rotation) as GameObject;
    }
}
