using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class ParsingWave
{
    private ArrayList names;
    private ArrayList intervals;
    private float inicial_interval;
    private float interval;
    private int enemy_number=0;
    public ParsingWave(float interval,XmlNode wave )
    {
        names = new ArrayList();
        this.inicial_interval = interval;
        this.interval = interval;
        intervals = new ArrayList();
        XmlNodeList enemies = wave.ChildNodes;
        foreach (XmlElement enemy in enemies)
        {
            if(enemy.Name == "enemy" && enemy.HasAttribute("name") && enemy.HasAttribute("interval"))
            {
                string name = enemy.GetAttribute("name");
                float inter = float.Parse(enemy.GetAttribute("interval"), CultureInfo.InvariantCulture);

                names.Add(name);
                intervals.Add(inter);
            }
            else
                throw new ParsingError("wave should have name and interval");
        }
    }


    public Boolean PlayWave(float deltaTime, ArrayList enemies_objects)
    {
        if(interval > 0)
        {
            interval -= deltaTime;
        }
        else
        {
            interval = (float)intervals[enemy_number];
            string name = (string)names[enemy_number];
            for(int i=0;i<enemies_objects.Count;i++)
            {
                if(((ParseEnemy)enemies_objects[i]).getName() == name)
                {
                    ((ParseEnemy)enemies_objects[i]).Spawn();
                    break;
                }
            }
            enemy_number++;
            if(enemy_number >= names.Count)
            {
                return true;
            }
        }
        return false;
    }
}
